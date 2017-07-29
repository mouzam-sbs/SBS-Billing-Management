using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Implementation;
using BLL.Interface;
using BOL.Common;

using System.Web.Mvc;
using System.Web.Routing;
using BOL.Extensions;
using HiQPdf;

namespace SBSBillingSoftware.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {

        BillingModel _BillingModel;
        private readonly IInvoice _invoiveBusiness;
        public InvoiceController()
        {
            _BillingModel = new BillingModel();
            _invoiveBusiness = new InvoiceBusiness();
        }
        // GET: Admin/Invoice
        public ActionResult Index(int? id)
        {
            if (id == null || id == 0)
            {
                return PageRedirection();
            }
            _BillingModel.OrderId = (Int32)id;
            _BillingModel = _invoiveBusiness.GetCustomerOrderDetailsByOrderId(_BillingModel);
            
            if (_BillingModel.BillingList == null || !_BillingModel.BillingList.Any())
            {
                return PageRedirection();
            }
            return View(_BillingModel);
        }

        private ActionResult PageRedirection()
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Billing", action = "Index" }));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ConvertHtmlPageToPdf(BillingModel model)
        {
            model = model ?? new BillingModel();
            model.pdfFileName = string.IsNullOrWhiteSpace(model.pdfFileName) ? "Invoice" : model.pdfFileName;
            model.htmlToPdf = string.IsNullOrWhiteSpace(model.htmlToPdf) ? "No data" : model.htmlToPdf;
            // get the HTML code of this view
            string htmlToConvert = model.htmlToPdf;

            // the base URL to resolve relative images and css
            String thisPageUrl = this.ControllerContext.HttpContext.Request.Url.AbsoluteUri;
            String baseUrl = thisPageUrl.Substring(0, thisPageUrl.Length -
                "Home/ConvertThisPageToPdf".Length);

            // instantiate the HiQPdf HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // hide the button in the created PDF
           // htmlToPdfConverter.hi = new string[]
                    //   { "#convertThisPageButtonDiv" };

            // render the HTML code as PDF in memory
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlToConvert, baseUrl);

            // send the PDF file to browser
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = model.pdfFileName+".pdf";

            return fileResult;
        }
    } 
}
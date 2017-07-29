using BLL.Implementation;
using BLL.Interface;
using BOL.Common;
using DAL.DataModel;
using DAL.GenericPattern.Implementation;
using DAL.GenericPattern.Interface;
using HiQPdf;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSBillingSoftware.Areas.Admin.Controllers
{
    public class OrderedListsController : Controller
    {
        private readonly IGenericPattern<Order> _Order;
        private readonly IOrder _OrderBusiness;
        public OrderedListsController()
        {
            _OrderBusiness = new OrderBusiness();
            _Order = new GenericPattern<Order>();
        }
        // GET: Admin/OrderedLists
        public ActionResult Index()
        {

            BillingModel _BillingModel = _OrderBusiness.GetOrderList(new BillingModel());
            return View(_BillingModel);
        }

        public FileResult ExportTo(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/AllInvoices.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "BillingOrders";


            reportDataSource.Value = _Order.GetAll().ToList();
           
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension = (ReportType == "Excel") ? "xlsx" : (ReportType == "Word" ? "doc" : "pdf");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding,
                                                out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=Invoice." + fileNameExtension);

            return File(renderedBytes, fileNameExtension);

        }

        public ActionResult ReportByDate()
        {
            OrderModel _orderModel = new OrderModel();
            var orders = _OrderBusiness.OrderList();
            return View(orders);
        }
        [HttpPost]
        public ActionResult ReportByDate(DateTime FromDate, DateTime ToDate)
        {

            DateTime FDate = FromDate;
            DateTime TDate = ToDate;
            
            OrderModel _orderModel = new OrderModel();
             _orderModel.OrderList = _OrderBusiness.OrderList().OrderList.Where(x => x.InvoiceDate >= FDate && x.InvoiceDate <=TDate).ToList();
            return View(_orderModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ConvertHtmlPageToPdf(OrderModel model)
        {
            model = model ?? new OrderModel();
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
            fileResult.FileDownloadName = model.pdfFileName + ".pdf";

            return fileResult;
        }
    }
}
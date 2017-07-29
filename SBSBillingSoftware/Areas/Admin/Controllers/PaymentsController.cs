using BLL.Implementation;
using BLL.Interface;
using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSBillingSoftware.Areas.Admin.Controllers
{
    public class PaymentsController : Controller
    {
        private PaymentTransactionModel _paymenttransactionmodel;
        private DepositToModel _DepositToModel;
        private PaymentModeModel _PaymentModeModel;
        private PaymentModel _paymentmodel;
        private readonly IPayments _PaymentsBs;
        private readonly IPaymentTransaction _PaymentTransactionBs;

        private readonly IOrder _OrderBs;


        private readonly IDepositTo _DepositToBs;

        private readonly IPaymentMode _PaymentModeBs;


        public PaymentsController()
        {
            _DepositToModel = new DepositToModel();
            _PaymentModeModel = new PaymentModeModel();
            _PaymentsBs = new PaymentsBs();
           // _PaymentTransactionBs = new PaymentTransactionBs();
            _OrderBs = new OrderBusiness();
            _PaymentsBs = new PaymentsBs();
            _DepositToBs = new DepositToBs();
            _PaymentModeBs = new PaymentModeBs();
            _paymentmodel = new PaymentModel();
            _paymenttransactionmodel = new PaymentTransactionModel();

        }
        // GET: Admin/Payments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RecordPayment(int? id=null)
        {
            if (id != null)
            {
                _paymentmodel.CustomerModelList = new CustomerBusiness().CustomerList().ToList();
                _paymentmodel.PaymentModeList = new PaymentModeBs().PaymentModeList().ToList();
                _paymentmodel.DeopsitToList = new DepositToBs().DepositToList().ToList();
                return View(_paymentmodel);
            }
            else
            {
                _paymentmodel.CustomerModelList = new CustomerBusiness().CustomerList().ToList();
                _paymentmodel.PaymentModeList = new PaymentModeBs().PaymentModeList().ToList();
                _paymentmodel.DeopsitToList = new DepositToBs().DepositToList().ToList();
                return View(_paymentmodel);
            }
        }


        [HttpPost]
        public ActionResult RecordPayment(FormCollection form, OrderModel model)
        {

            var keys = form.AllKeys.Where(x => x.StartsWith("txtPayment")).ToList();

            var obj = new OrderModel();
            obj.GrandTotal= Convert.ToDecimal(form["PaidAmount"]);
            obj.PaymentModeId = Convert.ToInt32(form["PaymentModeId"]);
            obj.PaymentDate = Convert.ToDateTime(form["PaymentDate"]);
            obj.Remark = form["Remark"];
            obj.DepositToId = Convert.ToInt32(form["DepositToId"]);
            obj.CustomerID = model.CustomerID;
           int paymentDetailId = _OrderBs.SavePaymentDetails(obj);
            foreach (var item in keys)
            {
                var currentKeyNum = item.Replace("txtPayment", "");
                obj = _OrderBs.Getbyid(Convert.ToInt32(form["OrderId" + currentKeyNum]));
                obj.PaymentDetailsId = paymentDetailId;
                obj.PaymentDate = Convert.ToDateTime(form["PaymentDate"]);
                obj.ID = Convert.ToInt32(form["OrderId"+currentKeyNum]);  
                decimal TotalPrice= Convert.ToDecimal(form["Amountval" + currentKeyNum]);
                decimal balanceAmount = Convert.ToDecimal(form["BalanceAmountval" + currentKeyNum]);
                obj.AmountPaid = Convert.ToDecimal(form["txtPayment" + currentKeyNum]);
                //obj.Balance =Convert.ToDecimal(TotalPrice-balanceAmount);
                obj.Balance = balanceAmount - obj.AmountPaid;
                if (obj.Balance == null || obj.Balance == 0)
                {
                    obj.Status = true;
                }
                _OrderBs.UpdatePayment(obj);
                _OrderBs.SavePayment(obj);
            }
            return RedirectToAction("Index", "PaymentReceipt", new { @id = paymentDetailId });
            return RecordPayment();
        }
       
        [HttpGet]
        public JsonResult GetInvoicebyId(int id)
        {
            var res = new OrderBusiness().CustomerInvoiceList(id).ToList();
            var total = res.Sum(x => x.Balance);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBalanceAmount(int id)
        {
            var res = new OrderBusiness().CustomerInvoiceList(id).ToList();
            var total = res.Sum(x => x.Balance);

            return Json(total, JsonRequestBehavior.AllowGet);
        }
    }
}
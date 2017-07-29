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
    public class PaymentReceiptController : Controller
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


        public PaymentReceiptController()
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
        // GET: Admin/PaymentReceipt
        public ActionResult Index(int id)
        {
            PaymentModel paymentModel = _OrderBs.GetPaymentReceiptBy(new PaymentModel { Id = id });
            return View(paymentModel);
        }
        //[HttpPost]
        //public ActionResult Index(int id)
        //{
        //    PaymentModel paymentModel = _OrderBs.GetPaymentReceiptBy(new PaymentModel { Id = id });
        //    return View(paymentModel);
        //}
    }
}
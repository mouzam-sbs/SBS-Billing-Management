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
    public class PaymentPlanController : Controller
    {
        private CustomerPaymentPlanModel _CustomerPaymentPlanModel;
        private readonly ICustomerPaymentPlan _CustomerPaymentPlanBs;

        private PaymentPlanMasterModel _PaymentPlanMasterModel;
        private readonly IPaymentPlanMaster _PaymentPlanMasterBs;

        public PaymentPlanController()
        {
            _CustomerPaymentPlanModel = new CustomerPaymentPlanModel();
            _CustomerPaymentPlanBs = new CustomerPaymentPlanBs();

            _PaymentPlanMasterModel = new PaymentPlanMasterModel();
            _PaymentPlanMasterBs = new PaymentPlanMasterBs();
        }

        // GET: Admin/PaymentPlanMaster
        public ActionResult Index()
        {
            ViewBag.Model = _PaymentPlanMasterBs.PaymentPlanMasterList().ToList();
            return View(new PaymentPlanMasterModel());
        }
        public ActionResult Create(int? id)

        {
            if (id != null)
            {
                _PaymentPlanMasterModel = _PaymentPlanMasterBs.GetById(Convert.ToInt32(id));
                _PaymentPlanMasterModel.PaymentPlanMasterLists = _PaymentPlanMasterBs.PaymentPlanMasterList().ToList();

            }
            else
            {
                _PaymentPlanMasterModel.PaymentPlanMasterLists = _PaymentPlanMasterBs.PaymentPlanMasterList().ToList();
            }

            return View(_PaymentPlanMasterModel);
        }


        [HttpPost]
        public ActionResult Create(PaymentPlanMasterModel model)
        {
            int i = 0;
            if (model != null)
            {
                model.Status = true;
                model.CreatedDate = DateTime.Now;
                i = _PaymentPlanMasterBs.Save(model);
            }
            if (i > 0)
            {
                TempData["msg"] = "Payment Added Successfully";
                return RedirectToAction("Index", "PaymentPlan", new { area = "Admin" });
            }
            else
            {
                _PaymentPlanMasterModel.PaymentPlanMasterLists = _PaymentPlanMasterBs.PaymentPlanMasterList().ToList();
                TempData["msg"] = "Plan Not Registered";
                return RedirectToAction("Create", _PaymentPlanMasterModel);
            }

        }


       
       

        // GET: Admin/CustomerPaymentPlan
        public ActionResult CustomerPaymentPlans()
        {
            var res = _CustomerPaymentPlanBs.CustomerPaymentPlanList();
            return View(res);
        }


        public ActionResult CreateCustomerPaymentPlan(int? id)

        {
            if (id != null)
            {
                _CustomerPaymentPlanModel = _CustomerPaymentPlanBs.GetById(Convert.ToInt32(id));
                _CustomerPaymentPlanModel.CustomerPaymentPlanLists = _CustomerPaymentPlanBs.CustomerPaymentPlanList().ToList();
                _CustomerPaymentPlanModel.OrderList = _CustomerPaymentPlanBs.OrderList().ToList();
                _CustomerPaymentPlanModel.CustomerModelList = _CustomerPaymentPlanBs.CustomerList().ToList();
                _CustomerPaymentPlanModel.PaymentPlanMasterLists = _CustomerPaymentPlanBs.PaymentPlanMasterList().ToList();

            }
            else
            {
                var data = _CustomerPaymentPlanBs.CustomerPaymentPlanList().Where(x => x.InvoiceId == id).FirstOrDefault();
                _CustomerPaymentPlanModel.CustomerPaymentPlanLists = _CustomerPaymentPlanBs.CustomerPaymentPlanList().ToList();
                _CustomerPaymentPlanModel.OrderList = _CustomerPaymentPlanBs.OrderList().ToList();
                _CustomerPaymentPlanModel.CustomerModelList = _CustomerPaymentPlanBs.CustomerList().ToList();
                _CustomerPaymentPlanModel.PaymentPlanMasterLists = _CustomerPaymentPlanBs.PaymentPlanMasterList().ToList();

            }

            return View(_CustomerPaymentPlanModel);
        }


        [HttpPost]
        public ActionResult Create(CustomerPaymentPlanModel model)
        {
            int i = 0;
            if (model != null)
            {
                i = _CustomerPaymentPlanBs.Save(model);
            }
            if (i > 0)
            {
                TempData["msg"] = "Customer Payment Created Successfully";
                return RedirectToAction("Index", "CustomerPaymentPlan", new { area = "Admin" });
            }
            else
            {
                _CustomerPaymentPlanModel.CustomerPaymentPlanLists = _CustomerPaymentPlanBs.CustomerPaymentPlanList().ToList();
                TempData["msg"] = "Customer Payment Not Created";
                return RedirectToAction("Create", _CustomerPaymentPlanModel);
            }

        }
    }
}
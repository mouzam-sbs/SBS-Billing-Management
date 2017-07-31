using BLL.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSBillingSoftware.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserBusiness _UserBusiness;
        private readonly CategoryBusiness _CategoryBusiness;
        private readonly ProductBusiness _ProductBusiness;
        private readonly OrderBusiness _OrderBusiness;
        private readonly OrderedListBs _OrderedListBs;
        private readonly OrderReportListBs _OrderReportListBs;
        public HomeController()
        {

            _UserBusiness = new UserBusiness();
            _CategoryBusiness = new CategoryBusiness();
            _ProductBusiness = new ProductBusiness();
            _OrderBusiness = new OrderBusiness();
            _OrderedListBs = new OrderedListBs();
            _OrderReportListBs = new OrderReportListBs();

        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            if (TempData["msg"] != null)
            {
                TempData["Message"] = TempData["msg"];
            }
            TempData["NewUserRegistration"] = _UserBusiness.UserRegistrationList().Count();
            TempData["Categories"] = _CategoryBusiness.CategoryList().Count();
            TempData["Products"] = _ProductBusiness.ProductList().Count();
            //TempData["Orders"] = _OrderReportListBs.OrderDetailsList().Count();
            TempData["Orders"] = _OrderBusiness.orderlist().Count();

            return View();
        }
    }
}
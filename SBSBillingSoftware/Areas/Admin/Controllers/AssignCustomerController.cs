using BLL.Implementation;
using BOL.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSBillingSoftware.Areas.Admin.Controllers
{
    public class AssignCustomerController : Controller
    {
        // GET: Admin/AssignCustomer
        public ActionResult Index()
        {
            AssignCustomerModel obj = new AssignCustomerModel();
           var res = new CustomerBusiness().CustomerList().ToList();
            ViewBag.UserList = new UserBusiness().UserList().ToList();

            obj.CustomerList1 = (from item in res
                                 select new SelectListItem
                                 {
                                     Text = item.CustomerName,
                                     Value = item.ID.ToString()
                                 });
            List<SelectListItem> list = new List<SelectListItem>();
            obj.CustomerList2 = list;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(AssignCustomerModel model)
        {

            AssignCustomerBs _AssignCustomerBs = new AssignCustomerBs();

            if (model!=null)
            {
                foreach (var item in model.SelectedCustomers)
                {
                    model.CustomerId = item;
                    model.CreatedDate = DateTime.Now;
                    _AssignCustomerBs.Save(model);
                }
            }
            return RedirectToAction("Index");
        }

        public class RootObject
        {
            public List<int> Ids { get; set; }
        }
    }
}
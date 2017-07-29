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
    public class CustomerController : Controller
    {
        private CustomerModel _CustomerModel;
        private readonly ICustomer _CustomerBusiness;

        public CustomerController()
        {
            _CustomerModel = new CustomerModel();
            _CustomerBusiness = new CustomerBusiness();
        }
        // GET: Admin/Customer
        public ActionResult Index()
        {

            _CustomerModel.CustomerModelList = _CustomerBusiness.CustomerList().ToList();
            return View(_CustomerModel);
        }
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                _CustomerModel = _CustomerBusiness.Getbyid(Convert.ToInt32(id));
                _CustomerModel.CustomerModelList = _CustomerBusiness.CustomerList().ToList();
            }
            else
            {
                _CustomerModel.CustomerModelList = _CustomerBusiness.CustomerList().ToList();

            }
            return View(_CustomerModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model, HttpPostedFileBase[] Files)
        {
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.CustomerName))
                    {
                        if (!string.IsNullOrWhiteSpace(model.CustomerName) && Files != null)
                        {
                            if (Files != null)
                            {
                                model.ProfilePic1 = new byte[Files[0].ContentLength];
                                Files[0].InputStream.Read(model.ProfilePic1, 0, Files[0].ContentLength);
                            }
                            if (Files[1] != null)
                            {
                                model.AttachmentPic1 = new byte[Files[1].ContentLength];
                                Files[1].InputStream.Read(model.AttachmentPic1, 0, Files[1].ContentLength);
                            }

                            if (Files[2] != null)
                            {
                                model.AttachmentPic2 = new byte[Files[2].ContentLength];
                                Files[2].InputStream.Read(model.AttachmentPic2, 0, Files[2].ContentLength);
                            }
                            if (Files[3] != null)
                            {
                                model.AttachmentPic3 = new byte[Files[3].ContentLength];
                                Files[3].InputStream.Read(model.AttachmentPic3, 0, Files[3].ContentLength);
                            }
                            if (Files[4] != null)
                            {
                                model.IdProofPic4 = new byte[Files[4].ContentLength];
                                Files[4].InputStream.Read(model.IdProofPic4, 0, Files[4].ContentLength);
                            }
                            var AddCategory = _CustomerBusiness.SaveCustomer(model);


                        }
                        _CustomerModel.CustomerModelList = _CustomerBusiness.CustomerList();
                        return View("Index", _CustomerModel);
                    }
                }
            }

            catch (Exception e1)
            {
                TempData["Msg"] = " Not Inserted " + e1.Message;

            }

            return View("Index", _CustomerModel);
        }

        public ActionResult Details(int? id)
        {

            var res = _CustomerBusiness.Getbyid(Convert.ToInt32(id));

            return View(res);
        }

    }
}

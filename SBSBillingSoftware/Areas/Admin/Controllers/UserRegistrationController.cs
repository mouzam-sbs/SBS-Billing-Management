using BLL.Implementation;
using BOL.Common;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSBillingSoftware.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class UserRegistrationController : Controller
    {
        private readonly UserModel _userModel;
        private readonly UserBusiness _userRegistrationBs;
        public UserRegistrationController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserBusiness();
        }

        public ActionResult Index(int? i)
        {

            var varial = _userRegistrationBs.UserRegistrationList();
            return View(varial);
        }

        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                var Varial = _userRegistrationBs.GetById(Convert.ToInt32(id));
                _userModel.UserModelList = _userRegistrationBs.UserRegistrationList().ToList();
                return View(Varial);

            }
            else
            {

                _userModel.UserModelList = _userRegistrationBs.UserRegistrationList().ToList();
                return View(_userModel);

            }

        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            int i = 0;
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    UserBusiness obj = new UserBusiness();
                    var id = obj.UserRegistrationList().ToList();
                }
                i = _userRegistrationBs.Save(model);
                if (i > 0)
                {
                    _userModel.UserModelList = _userRegistrationBs.UserRegistrationList().ToList();
                    TempData["msg"] = "Registered Successfully";
                }
                else
                {
                    TempData["msg"] = " Not Registered ";
                }
            }

            return RedirectToAction("Index", "Login", new { area = "Admin" });

        }
    }
}
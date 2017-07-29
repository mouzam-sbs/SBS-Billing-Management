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
    public class CategoryController : Controller
    {
        private CategoryModel _CategoryModel;
        private readonly ICategory _CategoryBusiness;

        public CategoryController()
        {
            _CategoryModel = new CategoryModel();
            _CategoryBusiness = new CategoryBusiness();
        }
        // GET: Admin/Category1
        public ActionResult Index()
        {
            _CategoryModel.CategoryList = _CategoryBusiness.CategoryList().ToList();
            return View(_CategoryModel);
        }

        public ActionResult Create(int? id)
        {
            if (id != 0)
            {
                _CategoryModel = _CategoryBusiness.Getbyid(Convert.ToInt32(id));

            }
            _CategoryModel.CategoryList = _CategoryBusiness.CategoryList().ToList();
            return View(_CategoryModel);
        }

        public ActionResult AddCategory(CategoryModel model)
        {
            if (model != null)
            {
                if (!string.IsNullOrWhiteSpace(model.CategoryName))
                {
                    var AddCategory = _CategoryBusiness.SaveCategory(model);
                }
                _CategoryModel.CategoryList = _CategoryBusiness.CategoryList();
                return View("Index", _CategoryModel);
            }
            return RedirectToAction("Index", _CategoryModel);
        }
    }
}
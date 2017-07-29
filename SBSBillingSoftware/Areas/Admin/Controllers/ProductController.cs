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
    public class ProductController : Controller
    {
        private ProductModel _ProductModel;
        private readonly IProduct _ProductBusiness;
        private readonly ICategory _CategoryBusiness;


        public ProductController()
        {
            _ProductModel = new ProductModel();
            _ProductBusiness = new ProductBusiness();
            _CategoryBusiness = new CategoryBusiness();
        }
        // GET: Admin/Product
        public ActionResult Index(int? id)
        {
            _ProductModel.ProductList = _ProductBusiness.ProductList().ToList();
            return View(_ProductModel);
        }

        public ActionResult Create(int? id)
        {
            _ProductModel.CategoryList = _CategoryBusiness.CategoryList().ToList();
            return View(_ProductModel);
        }

        [HttpPost]
        public ActionResult Create(ProductModel model, HttpPostedFileBase Files)
        {
            try
            {
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ProductName) && Files != null)
                    {
                        model.Image = new byte[Files.ContentLength];
                        Files.InputStream.Read(model.Image, 0, Files.ContentLength);
                        var AddProduct = _ProductBusiness.SaveProduct(model);
                        if (AddProduct!=0)
                        {
                            TempData["Msg"] = "Product Registered Sucessfully";
                        }
                    }
                 
                
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = " Not Inserted " + e1.Message;
            }
            _ProductModel.CategoryList = _CategoryBusiness.CategoryList().ToList();
            return View(_ProductModel);
        }

        public ActionResult ProductModal(int? id)
        {
            try
            {
                if (id != null)
                {
                    _ProductModel = _ProductBusiness.GetProductbyId(Convert.ToInt32(id));
                }
                _ProductModel = _ProductModel ?? new ProductModel();
                _ProductModel.CategoryList = _CategoryBusiness.CategoryList().ToList();
                return PartialView("_AddProduct", _ProductModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
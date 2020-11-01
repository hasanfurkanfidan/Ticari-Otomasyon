using Hff.Business.Abstract;
using Hff.Entities.Concrete;
using Hff.MVC.Models.ListViewModels;
using Hff.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var models = new List<ProductListViewModel>();
            var products = _productService.GetWithCategories();
            foreach (var product in products)
            {
                var model = new ProductListViewModel();
                model.Category = product.Category;
                model.Picture = product.Picture;
                model.SalePrice = product.SalePrice;
                model.Stock = product.Stock;
                model.TradeMark = product.TradeMark;
                model.ProductId = product.ProductId;
                model.PurchasePrice = product.PurchasePrice;
                model.Picture = product.Picture;
                model.Status = product.Status;
                model.ProductName = product.ProductName;
                models.Add(model);
            }
           
            return View(models);
        }
        [HttpGet]
        public ActionResult Add()
        {

            List<SelectListItem> Items = (from category in _categoryService.GetList()
                                          select new SelectListItem
                                          {
                                              Text = category.CategoryName,
                                              Value = category.CategoryId.ToString()
                                          }
                                          ).ToList();
          
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Pasif", Value = "false" } );
            Status.Add(new SelectListItem { Text = "Aktif", Value = "true" });
            ViewBag.Status = Status;
            ViewBag.Items = Items;
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductAddViewModel model)
        {
            var product = new Product();
            product.CategoryId = model.CategoryId;
            product.ProductName = model.ProductName;
            product.Status = model.Status;
            product.Picture = model.Picture;
            product.SalePrice = model.SalePrice;
            product.PurchasePrice = model.PurchasePrice;
            product.Stock = model.Stock;
            product.TradeMark = model.TradeMark;
            _productService.Create(product);
            return Redirect("/Product/Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var product = _productService.GetWithCategories().Where(p => p.ProductId == id).FirstOrDefault();
            var model = new ProductListViewModel();
            model.ProductId = product.ProductId;
            model.CategoryId= product.CategoryId;
            model.Status = product.Status;
            model.SalePrice = product.SalePrice;
            model.PurchasePrice = product.PurchasePrice;
            model.Stock = product.Stock;
            model.ProductName = product.ProductName;
            model.TradeMark = product.TradeMark;
            model.Picture = product.Picture;
            List<SelectListItem> Items = (from category in _categoryService.GetList()
                                          select new SelectListItem
                                          {
                                              Text = category.CategoryName,
                                              Value = category.CategoryId.ToString(),
                                          }
                                          ).ToList();

            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Pasif", Value = "false" });
            Status.Add(new SelectListItem { Text = "Aktif", Value = "true" });
            ViewBag.Status = Status;
            ViewBag.Items = Items;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(ProductListViewModel model)
        {
            var product = _productService.GetById(model.ProductId);
            product.Picture = model.Picture;
            product.ProductName = model.ProductName;
            product.SalePrice = model.SalePrice;
            product.Status = model.Status;
            product.TradeMark = model.TradeMark;
            product.CategoryId= model.CategoryId;
            product.PurchasePrice = model.PurchasePrice;
            product.Stock = model.Stock;
            _productService.Update(product);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deletedProduct = _productService.GetById(id);
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeStatus(int id)
        {
            var product = _productService.GetById(id);
            if (product.Status == true)
            {
                product.Status = false;
            }
            else
            {
                product.Status = true;
            }
            _productService.Update(product);
            return RedirectToAction("Index");
        }
    }
}
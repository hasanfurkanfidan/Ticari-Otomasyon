using Hff.Business.Abstract;
using Hff.Entities.Concrete;
using Hff.MVC.Models.ListViewModels;
using Hff.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: Category
        public ActionResult Index()
        {
            var model = new CategoryListViewModel();
            model.Categories = _categoryService.GetList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CategoryAddViewModel model)
        {
            var category =   _categoryService.Create(new Category { CategoryName=model.CategoryName});
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = new CategoryViewModel();
            var data = _categoryService.GetById(id);
            model.CategoryName = data.CategoryName;
            model.CategoryId = data.CategoryId;
                

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(CategoryViewModel model)
        {
            var category = _categoryService.GetById(model.CategoryId);
            category.CategoryName = model.CategoryName;
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}
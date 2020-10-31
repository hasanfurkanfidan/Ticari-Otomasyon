using Hff.Business.Abstract;
using Hff.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IProductService _productService;
        public GalleryController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Gallery
        public ActionResult Index()
        {
            var models =new List<GalleryViewModel>();
            var products = _productService.GetList();
            foreach (var product in products)
            {
                var model = new GalleryViewModel();
                model.ImageUrls = product.Picture;
                models.Add(model);
            }
            return View(models);
        }
    }
}
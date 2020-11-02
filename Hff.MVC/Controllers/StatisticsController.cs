using Hff.Business.Abstract;
using Hff.MVC.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    [Authorize]

    public class StatisticsController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IProductService _productService;
        private readonly ISaleProcessService _saleProcessService;
        private readonly ICategoryService _categoryService;
        // GET: Statistics

        public StatisticsController(ICustomerService customerService,IEmployeeService employeeService,IProductService productService,ISaleProcessService saleProcessService,ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _employeeService = employeeService;
            _productService = productService;
            _saleProcessService = saleProcessService;
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            var model = new StatisticsViewModel();
            model.CountOfProduct = _productService.GetList().Count();
            model.CountOfCategory = _categoryService.GetList().Count();
            model.CountOfCustomer = _customerService.GetList().Count();
            model.CountOfRefigerator = _productService.GetList().Where(p => p.ProductName.Contains("Buzdolabı")).Count();
            model.CountOfStock = _productService.GetList().Select(p => p.Stock).Sum();
            model.CountOfPresentSales = _saleProcessService.GetList().Where(p => p.Date == DateTime.Today).Count();
            model.CountOfTrademark = _productService.GetList().DistinctBy(p => p.TradeMark).Count();
            model.MaxPrice = _productService.GetList().Select(p => p.SalePrice).Max();
            model.MinPrice = _productService.GetList().Select(p => p.SalePrice).Min();
            model.AmountInTheSafe = _saleProcessService.GetList().Select(p => p.Total).Sum();
            model.TodayAmountInTheSafe = _saleProcessService.GetList().Where(p=>p.Date==DateTime.Today).Select(p => p.Total).Sum();
            model.CountOfEmployee = _employeeService.GetList().Count();
            model.CountOfRefigerator = _productService.GetList().Where(p => p.ProductName.Contains("Laptop")).Count();
            model.MaxTrademark = _productService.GetList().GroupBy(p => p.TradeMark).OrderByDescending(p => p.Count()).Select(a => a.Key).FirstOrDefault();

            model.CriticalStock = _productService.GetList().Where(p => p.Stock < 2).Count();
            return View(model);
        }
    }
}
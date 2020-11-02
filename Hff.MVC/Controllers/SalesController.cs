using Hff.Business.Abstract;
using Hff.Entities.Concrete;
using Hff.MVC.Models.ListViewModels;
using Hff.MVC.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    [Authorize]

    public class SalesController : Controller
    {
        private ISaleProcessService _saleProcessService;
        private ICustomerService _customerService;
        private IEmployeeService _employeeService;
        private IProductService _productService;
        public SalesController(ISaleProcessService saleProcessService, IEmployeeService employeeService, ICustomerService customerService, IProductService productService)
        {
            _saleProcessService = saleProcessService;
            _customerService = customerService;
            _employeeService = employeeService;
            _productService = productService;
        }
        public ActionResult Index(int pageIndex=1)
        {
            var model = new SaleProcessListViewModel();
            model.SalesProcesses = _saleProcessService.GetSaleProcessesWithEverything(null).ToList();
            var response = model.SalesProcesses.ToPagedList(pageIndex, 10);
            return View(response);
        }
        [HttpGet]
        public ActionResult ToSell()
        {
            var customers = (from customer in _customerService.GetList()
                             select new SelectListItem
                             {
                                 Text = customer.CustomerName + " " + customer.CustomerSurname,
                                 Value = customer.CustomerId.ToString()
                             }
                             ).ToList();
            var employees = (from employee in _employeeService.GetList()
                             select new SelectListItem
                             {
                                 Text = employee.EmployeeName + " " + employee.EmployeeSurname,
                                 Value = employee.EmployeeId.ToString()
                             }).ToList();
            var products = (from product in _productService.GetList()
                            select new SelectListItem
                            {
                                Text = product.ProductName,
                                Value = product.ProductId.ToString()
                            }).ToList();
            ViewBag.Customers = customers;
            ViewBag.Employees = employees;
            ViewBag.Products = products;

            return View();
        }

        public ActionResult ToSell(SalesAddViewModel model) {
            var product = _productService.GetById(model.ProductId);
            if (product.Stock>model.Quantity)
            {
                _saleProcessService.Create(new SalesProcess
                {
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    CustomerId = model.CustomerId,
                    EmployeeId = model.EmployeeId,
                    Total = model.Total,
                    Price = model.Price,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                short quantity = Convert.ToInt16(model.Quantity);

                product.Stock = product.Stock - quantity;

                _productService.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

            
           
        }
        public ActionResult Update(int id)
        {
            var sale = _saleProcessService.GetById(id);
            var customers = (from customer in _customerService.GetList()
                             select new SelectListItem
                             {
                                 Text = customer.CustomerName + " " + customer.CustomerSurname,
                                 Value = customer.CustomerId.ToString()
                             }
                           ).ToList();
            ViewBag.Customers = customers;
            var model = new SaleViewModel();
            model.Id = id;
            model.Price = sale.Price;
            model.Total = sale.Total;
            model.Quantity = sale.Quantity;
            model.ProductId = sale.ProductId;
            model.CustomerId = sale.CustomerId;
            model.Date = sale.Date;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(SaleViewModel model)
        {

            var sale = _saleProcessService.GetById(model.Id);
            sale.Price = model.Price;
            sale.Total = model.Total;
            sale.CustomerId = model.CustomerId;
            _saleProcessService.Update(sale);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var model = new SaleProcessListViewModel();
            var sale = _saleProcessService.GetById(id);
            var sales = _saleProcessService.GetSaleProcessesWithEverything(p => p.SaleId == sale.SaleId);
            model.SalesProcesses = sales;
            return View(model);
        }
        public ActionResult DetailTOPdf(int id)
        {
            var model = new SaleProcessListViewModel();
            var sale = _saleProcessService.GetById(id);
            var sales = _saleProcessService.GetSaleProcessesWithEverything(p => p.SaleId == sale.SaleId);
            model.SalesProcesses = sales;
            return View(model);
        }
        public ActionResult PdfToIndex()
        {
            var model = new SaleProcessListViewModel();
            model.SalesProcesses = _saleProcessService.GetSaleProcessesWithEverything(null);
            return View(model);
        }
    }
}
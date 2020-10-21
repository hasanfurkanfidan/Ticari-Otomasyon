using Hff.Business.Abstract;
using Hff.MVC.Models.ListViewModels;
using Hff.MVC.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ISaleProcessService _saleService;
        public CustomerController(ICustomerService customerService,ISaleProcessService saleService)
        {
            _saleService = saleService;
            _customerService = customerService;
        }
        // GET: Customer
        public ActionResult Index()
        {
            CustomerListViewModel model = new CustomerListViewModel();
            model.Customers = _customerService.GetList(p=>p.State==true);
            return View(model);
        }
        public ActionResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(CustomerAddViewModel model)
        {
           var customer =  _customerService.Create(new Entities.Concrete.Customer { CustomerName = model.CustomerName, CustomerSurname = model.CustomerSurname, CustomerMail = model.CustomerMail,State = true });
            return View();
            
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var customer = _customerService.GetById(id);
            var model = new CustomerViewModel();
            model.CustomerId = customer.CustomerId;
            model.CustomerMail = customer.CustomerMail;
            model.CustomerName = customer.CustomerName;
            model.CustomerSurname = customer.CustomerSurname;
            return View(model);
        }
        [HttpPost]
        public ActionResult Detail(CustomerViewModel model)
        {
            var updatedCustomer = _customerService.GetById(model.CustomerId);
            updatedCustomer.CustomerMail = model.CustomerMail;
            updatedCustomer.CustomerName = model.CustomerName;
            updatedCustomer.CustomerSurname = model.CustomerSurname;
            _customerService.Update(updatedCustomer);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           var customer =  _customerService.GetById(id);
            customer.State = false;
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }
        public ActionResult CustomerOrders(int id)
        {
            var model = new CustomerOrdersLisViewModel();
            model.CustomerId = id;
            model.SalesProcesses = _saleService.GetSaleProcessesWithEverything(p => p.CustomerId == id);
            return View(model);
        }
    }
}
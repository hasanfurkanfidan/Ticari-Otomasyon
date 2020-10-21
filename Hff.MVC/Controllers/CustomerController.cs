using Hff.Business.Abstract;
using Hff.MVC.Models.ListViewModels;
using Hff.MVC.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: Customer
        public ActionResult Index()
        {
            CustomerListViewModel model = new CustomerListViewModel();
            model.Customers = _customerService.GetList();
            return View(model);
        }
        public ActionResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(CustomerAddViewModel model)
        {
           var customer =  _customerService.Create(new Entities.Concrete.Customer { CustomerName = model.CustomerName, CustomerSurname = model.CustomerSurname, CustomerMail = model.CustomerMail });
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
            _customerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
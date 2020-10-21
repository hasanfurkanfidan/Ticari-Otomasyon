using Hff.Business.Abstract;
using Hff.MVC.Models.ListViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public ActionResult Index()
        {
            var model = new EmployeeListViewModel();
            var employees = _employeeService.GetEmployeesWithDepartment(null);
            model.Employees = employees;
            return View(model);
        }

        
    }
}
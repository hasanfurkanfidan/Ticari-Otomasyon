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
    [Authorize]

    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly ISaleProcessService _saleProcessService;
        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService,ISaleProcessService saleProcessService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _saleProcessService = saleProcessService;
        }
        public ActionResult Index()
        {
            var model = new EmployeeListViewModel();
            var employees = _employeeService.GetEmployeesWithDepartment(p => p.State == true);
            model.Employees = employees;
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            employee.State = false;
            _employeeService.Update(employee);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> departments = (from department in _departmentService.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = department.DepartmentName,
                                                    Value = department.DepartmentId.ToString()
                                                }
                                               ).ToList();
            ViewBag.Departments = departments;
            return View();
        }
        public ActionResult Add(EmployeeAddViewModel model)
        {
            _employeeService.Create(new Employee
            {
                EmployeeName = model.EmployeeName,
                EmployeeSurname = model.EmployeeSurname,
                DepartmentId = model.DepartmentId,
                Picture = model.Picture,
                State = true
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            List<SelectListItem> departments = (from department in _departmentService.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = department.DepartmentName,
                                                    Value = department.DepartmentId.ToString()
                                                }
                                               ).ToList();
            ViewBag.Departments = departments;
            var employee = _employeeService.GetById(id);
            var model = new EmployeeViewModel();
            model.DepartmentId = employee.DepartmentId;
            model.EmployeeId = employee.EmployeeId;
            model.EmployeeName = employee.EmployeeName;
            model.EmployeeSurname = employee.EmployeeSurname;
            model.Picture = employee.Picture;

            return View(model);


        }
        [HttpPost]
        public ActionResult Detail(EmployeeViewModel model)
        {
            var updatedEmployee = _employeeService.GetById(model.EmployeeId);
            updatedEmployee.DepartmentId = model.DepartmentId;
            updatedEmployee.EmployeeName = model.EmployeeName;
            updatedEmployee.EmployeeSurname = model.EmployeeSurname;
            updatedEmployee.Picture = model.Picture;
            _employeeService.Update(updatedEmployee);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult SalesOfEmployee(int id)
        {
            var model = new SalesOfEmployeeListViewModel();
            model.SalesProcesses = _saleProcessService.GetSaleProcessesWithEverything(p => p.EmployeeId == id);
            return View(model);

        }

    }
}
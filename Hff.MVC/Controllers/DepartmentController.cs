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

    public class DepartmentController:Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ISaleProcessService _saleProcessService;
        public DepartmentController(IDepartmentService departmentService,IEmployeeService employeeService,ISaleProcessService saleProcessService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
            _saleProcessService = saleProcessService;
        }
        public ActionResult Index()
        {
            var model = new DepartmentListViewModel();
            model.Departments = _departmentService.GetList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(DepartmentAddViewModel model)
        {
            _departmentService.Create(new Department
            {
                DepartmentName = model.DepartmentName
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            DepartmentViewModel model = new DepartmentViewModel();
            var department = _departmentService.GetById(id);
            model.DepartmentId = department.DepartmentId;
            model.DepartmentName = department.DepartmentName;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DepartmentViewModel model)
        {
            var department = _departmentService.GetById(model.DepartmentId);
            department.DepartmentName = model.DepartmentName;
            _departmentService.Update(department);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return RedirectToAction("Index");

        }
        public ActionResult Detail(int id)
        {
            var department = _departmentService.GetById(id);
            var employees =  _employeeService.GetEmployeesWithDepartment(p => p.DepartmentId == department.DepartmentId);
            var model = new DepartmentWithEmployeesModel();
            model.DepartmentName = department.DepartmentName;
            model.Employees = employees;
            return View(model);

        }
        public ActionResult SaleOfEmployee(int id)
        {
            var employee = _employeeService.GetById(id);
            var model = new SaleOfEmployeeListViewModel();
            model.EmployeeName = employee.EmployeeName;
            model.EmployeeSurname = employee.EmployeeSurname;
            model.SalesProcesses = _saleProcessService.GetSaleProcessesWithEverything(p => p.EmployeeId == employee.EmployeeId);
            return View(model);
        }
    }
}
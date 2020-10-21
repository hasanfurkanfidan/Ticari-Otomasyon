using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public string Picture { get; set; }
        public int DepartmentId { get; set; }
    }
}
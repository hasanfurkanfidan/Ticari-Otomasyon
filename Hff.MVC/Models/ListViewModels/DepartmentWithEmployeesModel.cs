using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ListViewModels
{
    public class DepartmentWithEmployeesModel
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

       public List<Employee> Employees { get; set; }
    }
}
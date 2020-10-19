using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ListViewModels
{
    public class SaleOfEmployeeListViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }

        public List<SalesProcess> SalesProcesses { get; set; }

    }
}
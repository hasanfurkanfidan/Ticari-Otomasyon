using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ListViewModels
{
    public class CustomerOrdersLisViewModel
    {
        public string CustomerName { get; set; }
        public string CustmerSurname { get; set; }

        public int CustomerId  { get; set; }

        public string CustomerMail { get; set; }

        public List<SalesProcess> SalesProcesses { get; set; }
    }
}
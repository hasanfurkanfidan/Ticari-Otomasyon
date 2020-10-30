using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class BillAddViewModel
    {
        public string SerialNumber { get; set; }
        public string RowNumber { get; set; }
        public DateTime Date { get; set; }
        public string TaxAdministration { get; set; }
        public string Hour { get; set; }
        public string Deliverer { get; set; }
        public string Receiver { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

    }
}
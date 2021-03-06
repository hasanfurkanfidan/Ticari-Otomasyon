﻿using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class ProductAddViewModel
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string TradeMark { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Picture { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
    }
}
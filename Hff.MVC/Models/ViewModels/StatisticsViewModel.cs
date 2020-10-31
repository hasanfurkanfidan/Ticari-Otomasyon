using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public int CountOfCustomer { get; set; }

        public int CountOfProduct { get; set; }

        public int CountOfCategory { get; set; }

        public int CountOfStock { get; set; }

        public int CountOfTrademark { get; set; }
        public decimal MaxPrice { get; set; }
        public string TopSeller { get; set; }
        public int CriticalStock { get; set; }
        public string MaxTrademark { get; set; }
        public int CountOfEmployee { get; set; }
        public decimal MinPrice { get; set; }

        public int CountOfLaptop { get; set; }
        public int CountOfRefigerator { get; set; }

        public decimal AmountInTheSafe { get; set; }

        public decimal TodayAmountInTheSafe { get; set; }


        public int CountOfPresentSales { get; set; }
    }
}
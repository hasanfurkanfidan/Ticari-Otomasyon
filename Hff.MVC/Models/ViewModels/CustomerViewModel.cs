﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerMail { get; set; }
    }
}
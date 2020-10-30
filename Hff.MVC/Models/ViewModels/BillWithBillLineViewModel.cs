using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hff.MVC.Models.ViewModels
{
    public class BillWithBillLineViewModel
    {
        public int BillId { get; set; }
        public string SerialNumber { get; set; }
        public string RowNumber { get; set; }
        public DateTime Date { get; set; }
        public string TaxAdministration { get; set; }
        public string Hour { get; set; }
        public string Deliverer { get; set; }
        public string Receiver { get; set; }
        public ICollection<BillLine> BillLines { get; set; }
        public decimal Total { get; set; }

        public static BillWithBillLineViewModel From(Bill bill)
        {
            return new BillWithBillLineViewModel
            {
                BillId = bill.BillId,
                SerialNumber = bill.SerialNumber,
                RowNumber = bill.RowNumber,
                Date = bill.Date,
                TaxAdministration = bill.TaxAdministration,
                Hour = bill.Hour,
                Deliverer = bill.Deliverer,
                Receiver = bill.Receiver,
                BillLines = bill.BillLines
            };
           

        }
        public static Bill To(BillWithBillLineViewModel model)
        {
            return new Bill
            {
                BillId = model.BillId,
                SerialNumber = model.SerialNumber,
                RowNumber = model.RowNumber,
                Date = model.Date,
                TaxAdministration = model.TaxAdministration,
                Hour = model.Hour,
                Deliverer = model.Deliverer,
                Receiver = model.Receiver,
                BillLines = model.BillLines
            };


        }
    }
}
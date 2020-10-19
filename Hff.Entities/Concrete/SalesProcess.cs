using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class SalesProcess:IEntity
    {
        //Satış Hareket
        [Key]
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }
    }
}

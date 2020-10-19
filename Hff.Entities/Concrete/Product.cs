using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TradeMark { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Picture { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public virtual  Category Category { get; set; }
        public ICollection< SalesProcess> SalesProcesses { get; set; }
    }
}

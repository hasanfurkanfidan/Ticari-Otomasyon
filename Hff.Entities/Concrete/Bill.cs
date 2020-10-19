using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Bill:IEntity
    {
        //Fatura
        [Key]
        public int BillId { get; set; }
        public string SerialNumber { get; set; }
        public string RowNumber { get; set; }
        public DateTime Date { get; set; }
        public int MyProperty { get; set; }
        public string TaxAdministration { get; set; }
        public DateTime Hour { get; set; }
        public string Deliverer { get; set; }
        public string Receiver { get; set; }

        public ICollection<BillLine> BillLines { get; set; }
    }
}

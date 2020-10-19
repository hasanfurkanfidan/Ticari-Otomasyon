using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Expense:IEntity
    {
        //Gider
        [Key]
        public int ExpenseId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}

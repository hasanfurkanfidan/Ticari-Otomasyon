using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Customer:IEntity
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerMail { get; set; }

        public ICollection< SalesProcess> SalesProcesses { get; set; }

    }
}

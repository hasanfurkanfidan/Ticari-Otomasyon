using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Department:IEntity
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}

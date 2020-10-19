using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Employee:IEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public string Picture { get; set; }
        public int DepartmentId { get; set; }

        public ICollection< SalesProcess> SalesProcesses { get; set; }

        public Department Department { get; set; }
    }
}

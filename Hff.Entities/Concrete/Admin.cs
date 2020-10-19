using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Entities.Concrete
{
   public class Admin:IEntity
    {
        [Key]   
        public int AdminId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [Column(TypeName ="Char")]
        
        public string Role { get; set; }
    }
}

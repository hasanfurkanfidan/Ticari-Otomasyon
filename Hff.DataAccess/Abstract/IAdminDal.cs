using DevFramework.Core.DataAccess;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Abstract
{
   public interface IAdminDal:IEntityRepository<Admin>
    {
    }
}

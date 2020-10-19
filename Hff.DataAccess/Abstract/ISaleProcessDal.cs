using DevFramework.Core.DataAccess;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Abstract
{
   public interface ISaleProcessDal:IEntityRepository<SalesProcess>
    {
        List<SalesProcess> GetSaleProcessesWithEverything(Expression<Func<SalesProcess,bool>>filter);
    }
}

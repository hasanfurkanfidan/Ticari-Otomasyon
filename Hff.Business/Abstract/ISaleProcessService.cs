using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
    public interface ISaleProcessService
    {
        List<SalesProcess> GetList(Expression<Func<SalesProcess, bool>> filter = null);

        SalesProcess GetById(int id);

        SalesProcess Create(SalesProcess salesProcess);

        void Delete(int id);

        SalesProcess Update(SalesProcess salesProcess);

        List<SalesProcess> GetSaleProcessesWithEverything(Expression<Func<SalesProcess, bool>> filter);
    }
}

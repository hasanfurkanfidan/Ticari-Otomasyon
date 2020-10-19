using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IBillLineService
    {
        List<BillLine> GetList(Expression<Func<BillLine, bool>> filter = null);

        BillLine GetById(int id);

        BillLine Create(BillLine billLine);

        void Delete(int id);

        BillLine Update(BillLine billLine);
    }
}

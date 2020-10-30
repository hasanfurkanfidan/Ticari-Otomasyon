using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IBillService
    {
        List<Bill> GetList(Expression<Func<Bill, bool>> filter = null);

        Bill GetById(int id);

        Bill Create(Bill bill);

        void Delete(int id);

        Bill Update(Bill bill);

        Bill GetWithBillLine(int id);
    }
}

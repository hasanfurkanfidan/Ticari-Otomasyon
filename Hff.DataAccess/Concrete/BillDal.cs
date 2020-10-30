using DevFramework.Core.DataAccess.EntityFramework;
using Hff.DataAccess.Abstract;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Concrete
{
    public class BillDal : EfEntityRepositoryBase<Bill, Context>, IBillDal
    {
        public Bill GetWithBillLine(int id)
        {
            using (var context = new Context())
            {
                var bill = context.Set<Bill>().Include("BillLines").Where(p => p.BillId == id).FirstOrDefault();
                return bill;
            }
        }
    }
}

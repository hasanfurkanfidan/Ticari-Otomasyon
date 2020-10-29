using DevFramework.Core.DataAccess.EntityFramework;
using Hff.DataAccess.Abstract;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Concrete
{
    public class SaleProcessDal : EfEntityRepositoryBase<SalesProcess, Context>, ISaleProcessDal
    {
        public List<SalesProcess> GetSaleProcessesWithEverything(Expression<Func<SalesProcess, bool>> filter)
        {
          
            using (var context = new Context())
            {
                if (filter == null) {
                    return context.SalesProcesses.Include("Customer").Include("Employee").Include("Customer").Include("Product").ToList();
                }
                else
                {
                    return context.SalesProcesses.Include("Customer").Include("Employee").Include("Customer").Include("Product").Where(filter).ToList();

                }

            }
        }
    }
}

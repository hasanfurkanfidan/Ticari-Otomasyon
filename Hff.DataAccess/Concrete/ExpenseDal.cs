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
   public class ExpenseDal:EfEntityRepositoryBase<Expense,Context>,IExpenseDal
    {
    }
}

using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IExpenseService
    {
        List<Expense> GetList(Expression<Func<Expense, bool>> filter = null);

        Expense GetById(int id);

        Expense Create(Expense expense);

        void Delete(int id);

        Expense Update(Expense expense);
    }
}

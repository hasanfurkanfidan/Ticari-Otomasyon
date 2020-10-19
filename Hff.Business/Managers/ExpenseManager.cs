using DevFramework.Core.Utilities.Mappings;
using Hff.Business.Abstract;
using Hff.DataAccess.Abstract;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Managers
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IExpenseDal _expenseDal;
        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }
        public Expense Create(Expense expense)
        {
            return AutoMapperHelper.MapToSameType(_expenseDal.Add(expense));
        }

        public void Delete(int id)
        {
            var deletedExpense = GetById(id);
            _expenseDal.Delete(deletedExpense);
        }

        public Expense GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_expenseDal.Get(p => p.ExpenseId == id));
        }

        public List<Expense> GetList(Expression<Func<Expense, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_expenseDal.GetList(filter));
        }

        public Expense Update(Expense expense)
        {
            return AutoMapperHelper.MapToSameType(_expenseDal.Update(expense));
        }
    }
}

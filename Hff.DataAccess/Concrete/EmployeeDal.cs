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
    public class EmployeeDal : EfEntityRepositoryBase<Employee, Context>, IEmployeeDal
    {
        public List<Employee> GetEmployeesWithDepartment(Expression<Func<Employee, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return context.Employees.Include("Department").Where(filter).ToList();
            }
        }
    }
}

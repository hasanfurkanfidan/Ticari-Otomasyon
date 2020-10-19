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
   public interface IEmployeeDal:IEntityRepository<Employee>
    {
        List<Employee> GetEmployeesWithDepartment(Expression<Func<Employee,bool>>filter=null);
    }
}

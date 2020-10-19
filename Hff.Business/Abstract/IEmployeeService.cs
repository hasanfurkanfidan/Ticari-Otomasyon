using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IEmployeeService
    {
        List<Employee> GetList(Expression<Func<Employee, bool>> filter = null);

        Employee GetById(int id);

        Employee Create(Employee employee);

        void Delete(int id);

        Employee Update(Employee employee);
        List<Employee> GetEmployeesWithDepartment(Expression<Func<Employee, bool>> filter = null);
    }
}

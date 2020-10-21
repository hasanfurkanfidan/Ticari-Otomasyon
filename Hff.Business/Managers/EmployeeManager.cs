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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public Employee Create(Employee employee)
        {
            return AutoMapperHelper.MapToSameType(_employeeDal.Add(employee));
        }

        public void Delete(int id)
        {
            var deletedEmployee = GetById(id);
            _employeeDal.Delete(deletedEmployee);
        }

        public Employee GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_employeeDal.Get(p => p.EmployeeId == id));
        }

        public List<Employee> GetEmployeesWithDepartment(Expression<Func<Employee, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList( _employeeDal.GetEmployeesWithDepartment(filter));
        }

        public List<Employee> GetList(Expression<Func<Employee, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_employeeDal.GetList(filter));
        }

        public Employee Update(Employee employee)
        {
            return AutoMapperHelper.MapToSameType(_employeeDal.Update(employee));
        }
    }
}

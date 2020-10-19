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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public Department Create(Department department)
        {
            return AutoMapperHelper.MapToSameType(_departmentDal.Add(department));
        }

        public void Delete(int id)
        {
            var deletedDepartment = GetById(id);
            _departmentDal.Delete(deletedDepartment);
        }

        public Department GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_departmentDal.Get(p => p.DepartmentId == id));
        }

        public List<Department> GetList(Expression<Func<Department, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_departmentDal.GetList(filter));
        }

        public Department Update(Department department)
        {
            return AutoMapperHelper.MapToSameType(_departmentDal.Update(department));
        }
    }
}

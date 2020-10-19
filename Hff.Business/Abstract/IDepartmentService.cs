using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IDepartmentService
    {
        List<Department> GetList(Expression<Func<Department, bool>> filter = null);

        Department GetById(int id);

        Department Create(Department department);

        void Delete(int id);

        Department Update(Department department);
    }
}

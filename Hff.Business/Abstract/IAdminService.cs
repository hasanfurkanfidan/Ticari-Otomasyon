using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetList(Expression<Func<Admin, bool>> filter=null);

        Admin GetById(int id);

        Admin Create(Admin admin);

        void Delete(int id);

        Admin Get(Expression<Func<Admin, bool>> filter = null);

        Admin Update(Admin admin);
    }
}

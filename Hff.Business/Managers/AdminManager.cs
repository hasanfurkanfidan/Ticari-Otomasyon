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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public Admin Create(Admin admin)
        {
            return AutoMapperHelper.MapToSameType(_adminDal.Add(admin));
        }

        public void Delete(int id)
        {
            var deletedAdmin = GetById(id);
            _adminDal.Delete(deletedAdmin);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.Get(filter);
        }

        public Admin GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_adminDal.Get(p => p.AdminId == id));
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_adminDal.GetList(filter));
        }

        public Admin Update(Admin admin)
        {
            return AutoMapperHelper.MapToSameType(_adminDal.Update(admin));
        }
    }
}

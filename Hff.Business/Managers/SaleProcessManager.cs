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
    public class SaleProcessManager : ISaleProcessService
    {
        private readonly ISaleProcessDal _saleProcessDal;
        public SaleProcessManager(ISaleProcessDal saleProcessDal)
        {
            _saleProcessDal = saleProcessDal;
        }
        public SalesProcess Create(SalesProcess salesProcess)
        {
            return AutoMapperHelper.MapToSameType(_saleProcessDal.Add(salesProcess));
        }

        public void Delete(int id)
        {
            var deletedSaleProcess = GetById(id);
            _saleProcessDal.Delete(deletedSaleProcess);
        }

        public SalesProcess GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_saleProcessDal.Get(p => p.SaleId == id));
        }

        public List<SalesProcess> GetList(Expression<Func<SalesProcess, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_saleProcessDal.GetList(filter));
        }

        public List<SalesProcess> GetSaleProcessesWithEverything(Expression<Func<SalesProcess, bool>> filter)
        {
            return _saleProcessDal.GetSaleProcessesWithEverything(filter);
        }

        public SalesProcess Update(SalesProcess salesProcess)
        {
            return AutoMapperHelper.MapToSameType(_saleProcessDal.Update(salesProcess));
        }
    }
}

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
    public class BillLineManager : IBillLineService
    {
        private readonly IBillLineDal _billLineDal;
        public BillLineManager(IBillLineDal billLineDal)
        {
            _billLineDal = billLineDal;
        }
        public BillLine Create(BillLine billLine)
        {
            return AutoMapperHelper.MapToSameType(_billLineDal.Add(billLine));
        }

        public void Delete(int id)
        {
            var deletedBillLine = GetById(id);
        }

        public BillLine GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_billLineDal.Get(p => p.BillLineId == id));
        }

        public List<BillLine> GetList(Expression<Func<BillLine, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_billLineDal.GetList(filter));
        }

        public BillLine Update(BillLine billLine)
        {
            return AutoMapperHelper.MapToSameType(_billLineDal.Update(billLine));
        }
    }
}

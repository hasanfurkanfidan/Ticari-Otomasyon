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
    public class BillManager : IBillService
    {
        private readonly IBillDal _billDal;
        public BillManager(IBillDal billDal)
        {
            _billDal = billDal;
        }
        public Bill Create(Bill bill)
        {
            return AutoMapperHelper.MapToSameType(_billDal.Add(bill));
        }

        public void Delete(int id)
        {
            var deletedBill = GetById(id);
            _billDal.Delete(deletedBill);
        }

        public Bill GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_billDal.Get(p => p.BillId == id));
        }

        public List<Bill> GetList(Expression<Func<Bill, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_billDal.GetList(filter));
        }

        public Bill Update(Bill bill)
        {
            return AutoMapperHelper.MapToSameType(_billDal.Update(bill));
        }
    }
}

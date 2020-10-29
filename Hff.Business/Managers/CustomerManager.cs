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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public Customer Create(Customer customer)
        {
            return AutoMapperHelper.MapToSameType(_customerDal.Add(customer));
        }

        public void Delete(int id)
        {
            var deletedCustomer = GetById(id);
            _customerDal.Delete(deletedCustomer);
        }

        public Customer GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_customerDal.Get(p => p.CustomerId == id));
        }

        public List<Customer> GetList(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetList(filter);
        }

        public Customer Update(Customer customer)
        {
            return AutoMapperHelper.MapToSameType(_customerDal.Update(customer));
        }
    }
}

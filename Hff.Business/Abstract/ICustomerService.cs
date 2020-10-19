using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface ICustomerService
    {
        List<Customer> GetList(Expression<Func<Customer, bool>> filter = null);

        Customer GetById(int id);

        Customer Create(Customer customer);

        void Delete(int id);

        Customer Update(Customer customer);
    }
}

using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface IProductService
    {
        List<Product> GetList(Expression<Func<Product, bool>> filter = null);

        Product GetById(int id);

        Product Create(Product product);

        void Delete(int id);

        Product Update(Product product);
        List<Product> GetWithCategories();
    }
}

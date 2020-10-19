using DevFramework.Core.DataAccess.EntityFramework;
using Hff.DataAccess.Abstract;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Concrete
{
   public class ProductDal:EfEntityRepositoryBase<Product,Context>,IProductDal
    {
        public List<Product> GetWithCategories()
        {
            using (var context = new Context())
            {
                return context.Products.Include("Category").ToList();

            }
            
        }
    }
}

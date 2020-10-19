using DevFramework.Core.DataAccess;
using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hff.DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
    {
        List<Product> GetWithCategories();
    }
}

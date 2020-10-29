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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Product Create(Product product)
        {
            return AutoMapperHelper.MapToSameType(_productDal.Add(product));
        }

        public void Delete(int id)
        {
            var deletedProduct = GetById(id);
            _productDal.Delete(deletedProduct);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetList(filter);
        }

        public List<Product> GetWithCategories()
        {
            return AutoMapperHelper.MapToSameTypeList(_productDal.GetWithCategories());
        }

        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}

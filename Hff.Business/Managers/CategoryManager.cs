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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public Category Create(Category category)
        {
            return AutoMapperHelper.MapToSameType(_categoryDal.Add(category));
        }

        public void Delete(int id)
        {
            var deletedCategory = GetById(id);
            _categoryDal.Delete(deletedCategory);
        }

        public Category GetById(int id)
        {
            return AutoMapperHelper.MapToSameType(_categoryDal.Get(p => p.CategoryId == id));
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return AutoMapperHelper.MapToSameTypeList(_categoryDal.GetList(filter));
        }

        public Category Update(Category category)
        {
            return AutoMapperHelper.MapToSameType(_categoryDal.Update(category));
        }
    }
}

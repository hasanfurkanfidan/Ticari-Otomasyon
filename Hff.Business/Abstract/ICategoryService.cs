using Hff.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.Business.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetList(Expression<Func<Category, bool>> filter = null);

        Category GetById(int id);

        Category Create(Category category);

        void Delete(int id);

        Category Update(Category category);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAllCategory();
        IDataResult<Category> GetCategoryByCategoryId(int categoryId);
        IResult Add(Category category);
        IResult Delete(int categoryId);
        IResult Update(Category category);
        IDataResult<Category> GetByCategoryName(string categoryName);
    }
}

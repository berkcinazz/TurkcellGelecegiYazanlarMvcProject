using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Category;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult AddCategory(CategoryForAddDto category);
        IResult DeleteCategory(int categoryId);
        IResult UpdateCategory(Category category);
        IDataResult<List<Category>> GetAllCategories();
        IDataResult<Category> GetCategoryById(int categoryId);
    }
}

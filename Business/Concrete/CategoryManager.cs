using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Category;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult AddCategory(CategoryForAddDto category)
        {
            var addToCategory = new Category()
            {
                Name = category.Name,
            };
            _categoryDal.Add(addToCategory);
            return new SuccessResult("Category Added");
        }
        public IResult DeleteCategory(int categoryId)
        {
            var result = _categoryDal.Get(i => i.Id == categoryId);
            if (result == null) return new ErrorResult("Category Not Found");
            _categoryDal.Delete(result);
            return new SuccessResult("Category Has Been Deleted");
        }
        public IDataResult<List<Category>> GetAllCategories()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }
        public IDataResult<Category> GetCategoryById(int categoryId)
        {
            var result = _categoryDal.Get(i => i.Id == categoryId);
            if (result == null) return new ErrorDataResult<Category>("Category Not Found");
            return new SuccessDataResult<Category>(result);
        }
        public IResult UpdateCategory(Category category)
        {
            var result = _categoryDal.Get(i => i.Id == category.Id);
            if (result == null) return new ErrorResult("Category Not Found");
            result.Name = category.Name;
            _categoryDal.Update(result);
            return new SuccessResult("Category Updated");
        }
    }
}

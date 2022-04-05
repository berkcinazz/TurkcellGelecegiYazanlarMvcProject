using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("get-all-categories")]
        public IActionResult GetAllcategories()
        {
            var result = _categoryService.GetAllCategories();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-category-by-id")]
        public IActionResult GetcategoryById(int categoryId)
        {
            var result = _categoryService.GetCategoryById(categoryId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-category")]
        public IActionResult Addcategory(CategoryForAddDto category)
        {
            var result = _categoryService.AddCategory(category);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-category")]
        public IActionResult Updatecategory(Category category)
        {
            var result = _categoryService.UpdateCategory(category);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-category")]
        public IActionResult Deletecategory(int categoryId)
        {
            var result = _categoryService.DeleteCategory(categoryId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}

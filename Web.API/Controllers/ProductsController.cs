using Business.Abstract;
using Entities.Dtos.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("get-all-products")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAllProducts();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct(ProductForAddDto product)
        {
            var result = _productService.AddNewProduct(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(int productId)
        {
            var result = _productService.DeleteProduct(productId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-product")]
        public IActionResult UpdateProduct(ProductForUpdateDto product)
        {
            var result = _productService.UpdateProduct(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-product-by-id")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetProductById(productId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}

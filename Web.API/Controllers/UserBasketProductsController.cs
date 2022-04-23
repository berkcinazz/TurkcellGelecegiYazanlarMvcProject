using Business.Abstract;
using Entities.Dtos.UserBasketProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBasketProductsController : ControllerBase
    {
        IUserBasketProductService _userBasketProductService;

        public UserBasketProductsController(IUserBasketProductService userBasketProductService)
        {
            _userBasketProductService = userBasketProductService;
        }
        [HttpGet("get-products-from-user-basket")]
        public IActionResult GetProductsFromUserBasket()
        {
            var result = _userBasketProductService.GetAllProductsFromBasket();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-product-to-user-basket")]
        public IActionResult AddProductToUserBasket(UserBasketProductsForAddDTO product)
        {
            var result = _userBasketProductService.AddProductToBasket(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-product-from-user-basket")]
        public IActionResult DeleteProductFromUserBasket(int productId)
        {
            var result = _userBasketProductService.DeleteProductFromBasket(productId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-product-in-user-basket")]
        public IActionResult UpdateProductInUserBasket(UserBasketProductsForUpdateDTO product)
        {
            var result = _userBasketProductService.UpdateProductFromBasket(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-product-from-user-basket-by-product-id")]
        public IActionResult GetProductFromUserBasketByProductId(int productId)
        {
            var result = _userBasketProductService.GetBasketItemByProductId(productId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}

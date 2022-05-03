using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UserBasketProductController : Controller
    {
        IUserBasketProductService _userBasketProductService;

        public UserBasketProductController(IUserBasketProductService userBasketProductService)
        {
            _userBasketProductService = userBasketProductService;
        }

        public IActionResult Index()
        {
            var userBasket = _userBasketProductService.GetAllProductsFromBasket();
            return View(userBasket);
        }
    }
}

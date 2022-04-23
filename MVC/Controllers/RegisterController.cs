using Business.Abstract;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserForRegisterDTO registerCredentials)
        {
            var result = _authService.Register(registerCredentials);
            ViewBag.AuthSuccess = result.Success;
            ViewBag.Message = result.Message;
            if (result.Success)
            {
                return View("Index");
            }
            return View("Index");//TO DO : redirect to login page
        }
    }
}

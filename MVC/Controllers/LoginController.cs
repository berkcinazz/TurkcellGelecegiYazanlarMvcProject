using Business.Abstract;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        IAuthService _authService;
        IHttpContextAccessor _httpContextAccessor;
        public LoginController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index(string ReturnUrl="")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDTO loginCredentials)
        {
            var result = _authService.Login(loginCredentials);
            if (result.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, result.Data.User.Email),
                    new Claim(ClaimTypes.NameIdentifier,result.Data.User.Id.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "LoginClaims");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return Redirect(loginCredentials.ReturnUrl == null ? "/" : loginCredentials.ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}

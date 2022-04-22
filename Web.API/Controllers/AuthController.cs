using Business.Abstract;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDTO registerCredentials)
        {
            var result = _authService.Register(registerCredentials);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDTO loginCredentials)
        {
            var result = _authService.Login(loginCredentials);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}

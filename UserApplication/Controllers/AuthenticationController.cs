using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserApplication.Models.RequestParameters.Auth;
using UserApplication.Service.Abstract;

namespace UserApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginRequestParameter());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestParameter loginRequest)
        {
            bool isLogin = await _userService.Login(loginRequest.Username, loginRequest.Password);
            if (!isLogin)
            {
                ViewBag.LoginError = "Kullanıcı Adı veya Parola hatalı.";
                return View(loginRequest);
            }
            var user = await _userService.GetById(loginRequest.Username);
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("secretKey",user.SecretKey)
            };
            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal cp = new ClaimsPrincipal(identity);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(15)
            };


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp, properties);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetById(userId);

            return View(user);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApplication.Service.Abstract;

namespace UserApplication.Controllers
{
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize(Roles ="admin,standart")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
    }
}

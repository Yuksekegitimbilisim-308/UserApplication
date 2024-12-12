using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserApplication.Models;
using UserApplication.Service.Abstract;

namespace UserApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var isLogin = await _userService.Login("melihok_", "1234");
            return View();
        }
    }
}

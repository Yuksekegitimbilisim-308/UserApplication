using Microsoft.AspNetCore.Mvc;

namespace UserApplication.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

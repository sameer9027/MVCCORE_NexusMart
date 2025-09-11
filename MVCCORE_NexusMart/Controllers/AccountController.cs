using Microsoft.AspNetCore.Mvc;

namespace MVCCORE_NexusMart.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }

}

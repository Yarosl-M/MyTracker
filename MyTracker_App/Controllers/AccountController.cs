using Microsoft.AspNetCore.Mvc;
using MyTracker_App.ViewModels.Auth;

namespace MyTracker_App.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login()
        {
            return Content("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return Content("Logout");
        }

        public async Task<IActionResult> SignUp()
        {
            return Content("SignUp");
        }
    }
}

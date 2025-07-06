using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTracker_App.Models.Auth;
using MyTracker_App.ViewModels.Auth;
using System.Security.Claims;

namespace MyTracker_App.Controllers
{
    public class AccountController(SignInManager<User> _signInManager,
        UserManager<User> _userManager, RoleManager<MyTrackerRole> _roleManager)
        : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
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

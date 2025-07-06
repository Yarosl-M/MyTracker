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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            // nnot succedded
            ModelState.AddModelError(string.Empty, "Неверно указаны входные данные.");
            return View(model);
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

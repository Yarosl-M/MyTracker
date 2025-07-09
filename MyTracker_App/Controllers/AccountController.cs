using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTracker_App.Models.Auth;
using MyTracker_App.Models.Domain;
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
            // not succeeded
            ModelState.AddModelError(string.Empty, "Неверно указаны входные данные.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                await _signInManager.SignOutAsync();
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("index", "home");
            return Content("Logout");
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
            return Content("SignUp");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // test stuff
            UserRole role;
            if (model.Name.StartsWith('#')) // # for operator
            {
                role = UserRole.Operator;
                //model.Name = string.Concat(model.Name.Skip(1));
                model.Name = model.Name.Substring(1);
            }
            else if (model.Name.StartsWith('$')) // $ for admin
            {
                role = UserRole.Admin;
                model.Name = model.Name.Substring(1);
            }
            else role = UserRole.RegularUser;

                var user = new User()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    NormalizedUserName = model.Email.ToUpper(),
                    DisplayName = model.Name,
                };
            var result = await _userManager.CreateAsync(user,
                model.Password);

            if (result.Succeeded)
            {
                if (!(await _roleManager.RoleExistsAsync(
                    UserRole.RegularUser.ToString())))
                {
                    await _roleManager.CreateAsync(
                        new MyTrackerRole(UserRole.RegularUser.ToString()));
                }

                await _userManager.AddToRoleAsync(user,
                    role.ToString());

                //await _userManager.AddToRoleAsync(user, UserRole.RegularUser.ToString());
                await _signInManager.SignInAsync(user, isPersistent: true);

                return RedirectToAction("index", "home");
            }
            // sign-up unsuccessful
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty,
                    error.Description);
            }
            return View(model);

            return Content("SignedUp");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WishList.Models;
using Microsoft.AspNetCore.Identity;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [AllowAnonymous]

        public IActionResult Register(Models.AccountViewModels.RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
                
            }

            var result = _userManager.CreateAsync(new ApplicationUser() { Email = model.Email, UserName = model.Email }, model.Password).Result;

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
                return View(model); 
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public IActionResult Login(Models.AccountViewModels.LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Login(model);

            }

            var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false).Result; 

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                return View(model);
            }
            return RedirectToAction("Index", "blabla");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult LogOut(Models.AccountViewModels.LoginViewModel model)
        {

            var result = _signInManager.SignOutAsync();

            return RedirectToAction("Index", "blabla");

        }
    }
}

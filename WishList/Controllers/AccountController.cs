using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WishList.Models;
using Microsoft.AspNetCore.Identity;

namespace WishList.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
        }
     
    }
}

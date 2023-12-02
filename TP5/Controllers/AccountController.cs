using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TP5.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> _userManager)
        {
            this._userManager = _userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }
    }
}

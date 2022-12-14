using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_People.Models;
using MVC_People.Models.ViewModels;

namespace MVC_People.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterViewModel newRegister)
        {
            AppUser user = new AppUser();
            user.FirstName = newRegister.FirstName;
            user.LastName = newRegister.LastName;
            user.BirthDate = newRegister.BirthDate;
            user.UserName = newRegister.UserName;
            user.PasswordHash = newRegister.Password;
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}

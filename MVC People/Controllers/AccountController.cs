using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_People.Data;
using MVC_People.Models;
using MVC_People.Models.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MVC_People.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async void Register(RegisterViewModel newRegister)
        {
            AppUser user = new AppUser { UserName = newRegister.UserName };
            IdentityResult result = await _userManager.CreateAsync(user, newRegister.Password);
            RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async void Login(LoginViewModel userLogin, SignInManager<AppUser> signInManager = default)
        {
            SignInResult signIn = await signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);
        }
        public async void Logout(SignInManager<AppUser> signInManager)
        {
            await signInManager.SignOutAsync();
        }
    }
}

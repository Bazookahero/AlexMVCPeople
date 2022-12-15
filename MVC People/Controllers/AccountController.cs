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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task Register(RegisterViewModel newRegister)
        {
            AppUser user = new AppUser { UserName = newRegister.UserName, PasswordHash = newRegister.Password };
            IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash);
            //IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (result.Succeeded)
                Console.WriteLine(result.ToString());
            else { Console.WriteLine(result.Errors.ToString()); }
            RedirectToAction(nameof(Login));
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task Login(LoginViewModel userLogin)
        {
            SignInResult signIn = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);
            if (signIn.Succeeded) {
                Console.WriteLine(signIn.Succeeded.ToString());
                RedirectToAction(nameof(Login));
            }
            else
                Console.WriteLine("Login failed");
            RedirectToAction(nameof(Login));
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
            RedirectToAction("Index", "Home");
        }
    }
}

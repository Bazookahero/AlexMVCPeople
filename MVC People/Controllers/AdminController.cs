using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_People.Models;
using MVC_People.Models.ViewModels;

namespace MVC_People.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Roles()
        {
            EditRolesViewModel viewModel = new EditRolesViewModel();
            viewModel.Users = _userManager.Users.ToList();
            viewModel.Roles = _roleManager.Roles.ToList();
            return View(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Roles(EditRolesViewModel editRole)
        {
            var user = await _userManager.FindByNameAsync(editRole.UserName);
            var result = await _userManager.AddToRoleAsync(user, editRole.RoleName);
            return RedirectToAction(nameof(Roles));
        }
    }
}

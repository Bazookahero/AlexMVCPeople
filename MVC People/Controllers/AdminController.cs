using Microsoft.AspNetCore.Mvc;

namespace MVC_People.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
    }
}

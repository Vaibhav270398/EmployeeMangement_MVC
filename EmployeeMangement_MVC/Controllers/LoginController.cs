using EmployeeMangement_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            return View();
        }
    }
}

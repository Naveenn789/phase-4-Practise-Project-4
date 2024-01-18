using Microsoft.AspNetCore.Mvc;
using WebAppBankDocker.Models;

namespace WebAppBankDocker.Controllers
{
    public class UserLoginController : Controller
    {
        readonly List<UserLogin> users = new List<UserLogin>()
        {
            new UserLogin() {UserName="Sam" ,Password="Sam@123"},
            new UserLogin() {UserName="Ram" ,Password="Ram@123"},
            new UserLogin() {UserName="Sameer" ,Password="Sameer@123"},
            new UserLogin() {UserName="Amir" ,Password="Amir@123"},
        };
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return RedirectToAction("Dashboard");
                }
                ViewBag.ErrorMessage = "Invalid username or password";
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}

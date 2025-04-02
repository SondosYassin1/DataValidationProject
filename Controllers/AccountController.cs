using DataValidationProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataValidationProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet] /*this is existed by default*/ 
        public IActionResult login()
        {
            return View();
        }

        // POST: /Account/Login 
        [HttpPost] //here it's not optional
        [ValidateAntiForgeryToken]
        public IActionResult login(UserLogin model)
        {
            if (!ModelState.IsValid) // Earlly retained pattern 
            {
                return View(model);
            }
            return RedirectToAction("LoginSuccess");
        }
        // GET: /Account/LoginSuccess
        [HttpGet]
        public IActionResult LoginSuccess()
        {
            return View();
        }

        // Method for remote validation
        [AcceptVerbs("GET","POST")]
        public IActionResult CheckUsername(string username)
        {
            // Simulate checking username against a database
            var takenUsernames = new List<string> { "admin", "root", "system", "moderator", "user"};
            if (takenUsernames.Contains(username.ToLower()))
            {
                return Json($"The username {username} is already taken.");
            }
            return Json(true);
        }
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register() //Normally in GET we do not take parameters 
        {
            return View();
        }

        // POST: /Account/Register 
        [HttpPost]
       [ValidateAntiForgeryToken]

        public IActionResult Register (UserRegistration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            return RedirectToAction("RegisterationSuccess");
        }

        // GET: /Account/RegisterationSuccess
        [HttpGet]
        public IActionResult RegisterationSuccess()
        {
            return View();
        }
    }
}



using DataValidationProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataValidationProject.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/Profile
        [HttpGet]
        public IActionResult Profile()
        {
            var model = new UserProfile
            {
                DateOfBirth = DateTime.Today.AddYears(-30),        //AddYears(-30): Subtracts 30 years from today's date.
                                                                   //Result: Sets the DateOfBirth to a date 30 years ago from today(by default).       
                PreferredContactMethod = ContactMethod.Email //Sets the preferred contact method to email by default.
            };
            return View(model);
        }

        // POST: /User/Profile 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(UserProfile model)
        {
            int calclatedAge = DateTime.Today.Year - model.DateOfBirth.Year;
            if(model.DateOfBirth.Date > DateTime.Today.AddYears(-calclatedAge))
            {
                calclatedAge--;
                
            }
            if (calclatedAge != model.Age)
            {
                ModelState.AddModelError("Age", "Age does not match the provided date of birth"); // in the ModelState add error to the Age field, then write the error massage 
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("ProfileSuccess");
        }
        //Get: /User/ProfileSuccess
        [HttpGet]
        public IActionResult ProfileSuccess()
        {
            return View();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataValidationProject.Models
{
    public class UserRegistration
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Usernmae must be between 3 and 20 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Usernmae can only contains letters, numbers, underscores and hyphens.")]
        [Remote(action: "CheckUsernmae", controller: "Account", ErrorMessage = "This username is already taken")]
        public string Username { get; set; }



        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }



        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Usernmae must be between 8 and 100 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^da-zA-Z]).{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match!")]
         public string ConfirmPassword { get; set; }




        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number format: (123) 456-7890 or 123-456-7890")]
        public string PhoneNumber { get; set; }
    }
}
                                                                                                                                                                                                                      
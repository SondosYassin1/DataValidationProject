using System.ComponentModel.DataAnnotations;

namespace DataValidationProject.Models
{
    public class UserProfile
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters.")]
        public string FullName { get; set; }


        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [PastDate(ErrorMessage = "Date of Birth must be in the past.")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "age")]
        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
        // Normally we do not put the date of birth and the age in the same class, but we put it here
        // because of the example in normal life we do not put it 
        public int Age { get; set; }


        [Display(Name = "annuelIncome")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000, ErrorMessage = "Income must be between 0 and $10,000,000")]
        public decimal? AnnualIncome { get; set; }
        // The ? after the datatype means the property can hold null values.

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required.")]
        //[DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;
        // string.Empty -> The property will never be null.


        [Display(Name = "Website URL")]
        [Url(ErrorMessage = "Please enter a valid URL address.")]
        public string? WebsiteUrl { get; set; }


        [Display(Name = "Profile Bio")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string? Bio { get; set; }


        [Display(Name = "Preferred Contant Method")]
        [Required(ErrorMessage = "Please select a preferred contant method.")]
        public ContactMethod PreferredContactMethod { get; set; }
    }
    public enum ContactMethod { Email, PhoneNumber, Mail }

    // To make a new data anotation you have to derive a class colld validation attribute 
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime) // Convert the data type value (object) if is a datetime to a datetime 
            {
                if (dateTime > DateTime.Today)
                {
                    return new ValidationResult(ErrorMessage ?? "Date must be in the past.");//?? means if it's null
                }
            }
            return ValidationResult.Success!;
           
        }
        //protected: Makes the method accessible only to this class and derived classes
        // ! -> to not receive warning 
    }
}

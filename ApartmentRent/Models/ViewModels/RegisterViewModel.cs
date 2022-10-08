using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class RegisterViewModel
    {



        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(255)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare("ConfirmEmail")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please confirm your email.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}

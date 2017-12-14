using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "User name", Prompt = "Enter a user name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Must be betweeen 1 and 30 characters")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "Enter your email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name", Prompt = "Enter your first name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Must be betweeen 1 and 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name", Prompt = "Enter your last name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Must be betweeen 1 and 30 characters")]
        public string LastName { get; set; }

        [Required]  
        [Display(Name = "Post code", Prompt = "Enter your post code")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Must be betweeen 4 and 10 characters")]
        [RegularExpression("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$", ErrorMessage = "Upper case only and include a space.")]
        public string PostCode { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobile phone no.", Prompt = "Enter your mobile no.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Must be 11 digits long with no spaces")]
        [RegularExpression(@"^(07\d{9}|447\d{9})$", ErrorMessage = "Phone number format is not valid.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Upload an optional profile photo")]
        public byte[] ProfilePhoto { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter a password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Retype your password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

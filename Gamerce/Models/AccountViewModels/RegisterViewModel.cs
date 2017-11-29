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
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]  
        [Display(Name = "Post Code")]
        [RegularExpression("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$", ErrorMessage = "Post code format is not valid. Lower case will not be accepted.")]
        public string PostCode { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobile phone no.")]
        [RegularExpression(@"^(07\d{9}|447\d{9})$", ErrorMessage = "Phone number format is not valid.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Upload an optional profile photo")]
        public byte[] ProfilePhoto { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

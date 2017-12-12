using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "User name")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Must be betweeen 1 and 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Must be betweeen 1 and 30 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Must be betweeen 4 and 10 characters")]
        [RegularExpression("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$", ErrorMessage = "Post code format is not valid. Lower case will not be accepted.")]
        public string PostCode { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobile phone no.", Prompt = "Enter your mobile no.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Must be 11 digits long with no spaces")]
        [RegularExpression(@"^(07\d{9}|447\d{9})$", ErrorMessage = "Phone number format is not valid.")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}

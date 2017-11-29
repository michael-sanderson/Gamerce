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
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        [RegularExpression("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$", ErrorMessage = "Post code format is not valid. Lower case will not be accepted.")]
        public string PostCode { get; set; }

        [Phone]
        [Display(Name = "Mobile phone no.")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}

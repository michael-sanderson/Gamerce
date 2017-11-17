using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Gamerce.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "You must enter a first name.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a last name.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter a date of birth.")]
        [DataType(DataType.Date)]
        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "You must enter a mobile phone number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(07/d{9}|447/d{9})$", ErrorMessage = "You must enter a valid mobile phone number.")]
        [DisplayName("Mobile phone number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "You must enter a valid email address.")]
        [EmailAddress]
        [DisplayName("Email address")]
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

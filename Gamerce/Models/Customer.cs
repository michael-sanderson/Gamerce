using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required (ErrorMessage ="You must enter a first name.")]
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
        [RegularExpression(@"^(07/d{9}|447/d{9})$", ErrorMessage ="You must enter a valid mobile phone number.")]
        [DisplayName("Mobile phone number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "You must enter a valid email address.")]
        [EmailAddress]
        [DisplayName("Email address")]
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

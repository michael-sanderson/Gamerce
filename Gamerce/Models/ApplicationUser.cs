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
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last name")]        
        public string LastName { get; set; }
        [Required]
        [DisplayName("Post code")]
        public string PostCode { get; set; }
        [DisplayName("Upload an optional profile photo")]
        public byte[] Photo { get; set; }
    }
}

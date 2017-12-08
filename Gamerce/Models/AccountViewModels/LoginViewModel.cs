using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models.AccountViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "User name", Prompt = "Enter your user name")]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name = "Password", Prompt = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

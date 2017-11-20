using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Condition
    {        
        public int ConditionID { get; set; }
        [Required]
        [DisplayName("Condition")]
        public string ProductCondition { get; set; }
        public ICollection<Product> Products { get; set; }    
}
}

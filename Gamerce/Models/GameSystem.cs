using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class GameSystem
    {
        public int GameSystemID { get; set; }
        [Required]
        [DisplayName("Game system")]
        public string ProductSystem { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

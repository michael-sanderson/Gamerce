using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required]
        [DisplayName("Genre")]
        public string ProductGenre { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

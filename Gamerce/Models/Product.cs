using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }
        [Required]
        public int GenreID { get; set; }
        [Required]
        public int SaleStatusID { get; set; }
        [Required]
        public int ConditionID { get; set; }
        [Required]
        public int GameSystemID { get; set; }
        public Genre Genre { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public Condition Condition { get; set; }
        public GameSystem GameSystem { get; set; }
    }
}

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
        [DisplayName("Seller")]
        public string ProductUserName { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public Decimal Price { get; set; }
        [Required]
        public int GenreID { get; set; }
        [Required]
        public int SaleStatusID { get; set; }
        [Required]
        public int ConditionID { get; set; }
        [Required]
        public int GameSystemID { get; set; }
        [DisplayName("Genre")]
        public Genre Genre { get; set; }
        [DisplayName("Status")]
        public SaleStatus SaleStatus { get; set; }
        [DisplayName("Condition")]
        public Condition Condition { get; set; }
        [DisplayName("System")]
        public GameSystem GameSystem { get; set; }
        [DisplayName("Date listed")]
        [DataType(DataType.Date)]
        public DateTime PostingDate  { get; set; }
        public string UserID { get; set; }
    }
}

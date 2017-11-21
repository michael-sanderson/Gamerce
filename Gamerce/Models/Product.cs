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
        [DisplayName("Game title")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Give a brief description of the game")]
        public string ProductDescription { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Enter the price you are looking for")]
        public Decimal Price { get; set; }
        [Required]
        [DisplayName("Game genre")]
        public int GenreID { get; set; }
        [Required]
        public int SaleStatusID { get; set; }
        [Required]
        [DisplayName("What is the condition of the game?")]
        public int ConditionID { get; set; }
        [Required]
        [DisplayName("What system is the game for?")]
        public int GameSystemID { get; set; }
        public Genre Genre { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public Condition Condition { get; set; }
        public GameSystem GameSystem { get; set; }
        public static DateTime PostingDate  { get; set; }
    }
}

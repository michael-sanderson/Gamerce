using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class SaleStatus
    {
        public int SaleStatusID { get; set; }
        [Required]
        [DisplayName("Status")]
        public string ProductSaleStatus { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

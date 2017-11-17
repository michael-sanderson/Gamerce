using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamerce.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string ProductTitle { get; set; }
        public double ProductPrice { get; set; }
        public string ProductGenre { get; set; }
        public string ProductSystem { get; set; }
        public string ProductCondition{ get; set; }
    }
}

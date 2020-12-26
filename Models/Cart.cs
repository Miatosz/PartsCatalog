using System.Collections.Generic;
using System.Linq;

namespace PartsCatalog.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
    }

    public class CartLine 
    {
        public int CartLineID {get; set;}
        public Product Product {get; set;}
        public int Quantity {get; set;}
    }
}
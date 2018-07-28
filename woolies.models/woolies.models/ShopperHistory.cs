using System.Collections.Generic;

namespace woolies.models
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}

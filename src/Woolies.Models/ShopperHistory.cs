using System.Collections.Generic;

namespace Woolies.Models
{
    public class ShopperHistoryModel
    {
        public int CustomerId { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}

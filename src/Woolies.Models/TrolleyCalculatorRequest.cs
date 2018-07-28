using System.Collections.Generic;

namespace Woolies.Models
{
    public class TrolleyCalculatorRequest
    {
        public List<ProductModel> Products { get; set; }
        public List<SpecialModel> Specials { get; set; }
        public List<QuantityModel> Quantities { get; set; }
    }
}

using System.Collections.Generic;

namespace woolies.models
{
    public class TrolleyCalculatorRequest
    {
        public List<Product> Products { get; set; }
        public List<SpecialModel> Specials { get; set; }
        public List<QuantityModel> Quantities { get; set; }
    }
}

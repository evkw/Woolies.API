using System.Collections.Generic;

namespace woolies.models
{
    public class SpecialModel
    {
        public List<QuantityModel> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}

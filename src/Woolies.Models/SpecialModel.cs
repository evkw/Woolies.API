using System.Collections.Generic;

namespace Woolies.Models
{
    public class SpecialModel
    {
        public List<QuantityModel> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}

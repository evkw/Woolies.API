using Woolies.Abstractions.Configuration;

namespace Woolies.api.Configuration
{
    public class WooliesTestConfiguration : IWooliesTestConfiguration
    {
        public string BaseApi { get; set; }
        public string Token { get; set; }
    }
}

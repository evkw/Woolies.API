using woolies.abstractions.Configuration;

namespace woolies.api.Configuration
{
    public class WooliesTestConfiguration : IWooliesTestConfiguration
    {
        public string BaseApi { get; set; }
        public string Token { get; set; }
    }
}

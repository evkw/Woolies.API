using System.Net.Http;

namespace woolies.abstractions.Repositories
{
    public interface IWooliesTestEndpointClient
    {
        HttpClient HttpClient { get; }
    }
}

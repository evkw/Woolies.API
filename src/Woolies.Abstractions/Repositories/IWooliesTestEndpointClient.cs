using System.Net.Http;

namespace Woolies.Abstractions.Repositories
{
    public interface IWooliesTestEndpointClient
    {
        HttpClient HttpClient { get; }
    }
}

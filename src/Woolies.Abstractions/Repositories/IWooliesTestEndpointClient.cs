using System;
using System.Net.Http;

namespace Woolies.Abstractions.Repositories
{
    public interface IWooliesTestEndpointClient
    {
        HttpClient HttpClient { get; }
        UriBuilder GetUri(string resource = null);
    }
}

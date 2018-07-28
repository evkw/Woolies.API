using System;
using System.Net.Http;
using Woolies.Abstractions.Repositories;

namespace Woolies.Repositories
{
    public class WooliesTestEndpointClient : IWooliesTestEndpointClient
    {
        public HttpClient HttpClient { get; }

        public WooliesTestEndpointClient()
        {
            var uriBuilder = new UriBuilder("http://dev-Wooliesx-recruitment.azurewebsites.net/api/resource/");
            uriBuilder.Query = "token=a4bd6f4e-aaba-4b32-8a20-98c247590e3b";

            this.HttpClient = new HttpClient
            {
                BaseAddress = uriBuilder.Uri
            };
        }
    }
}

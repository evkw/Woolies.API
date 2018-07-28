using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Woolies.Abstractions.Repositories;
using Woolies.Models;

namespace Woolies.repository
{
    public class ProductsRepository : IProductsRepository
    {
        private IWooliesTestEndpointClient _httpClient;
        //private ILogger _logger;

        public ProductsRepository(IWooliesTestEndpointClient httpClient)
        {
            this._httpClient = httpClient;
            //this._logger = logger;
        }

        private async Task<List<ProductModel>> GetProductsFromTestApi()
        {
            try
            {
                var baseUri = this._httpClient.GetUri("products");
                var response = await this._httpClient.HttpClient.GetAsync(baseUri.Uri);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductModel>>(result);
            }
            catch(HttpRequestException exception)
            {
                //this._logger.LogError("Unable to complete get request to resoure {resource}", "products");
                throw exception;
            }
        }

        private async Task<List<ShopperHistoryModel>> GetReccomendedProductsFromTestApi()
        {
            try
            {
                var baseUri = this._httpClient.GetUri("shopperHistory");
                var response = await this._httpClient.HttpClient.GetAsync(baseUri.Uri);
                var result = await response.RequestMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ShopperHistoryModel>>(result);
            }
            catch(HttpRequestException exception)
            {
                //this._logger.LogError("Unable to complete get request to resoure {resource}", "shopperHistory");
                throw exception;
            }
        }

        public async Task<List<ProductModel>> GetProducts(SortOptions sortOption)
        {
            var products = await this.GetProductsFromTestApi();

            switch (sortOption)
            {
                case SortOptions.Low:
                    return products.OrderBy(p => p.Price).ToList();
                case SortOptions.High:
                    return products.OrderByDescending(p => p.Price).ToList();
                case SortOptions.Ascending:
                    return products.OrderBy(p => p.Name).ToList();
                case SortOptions.Descending:
                    return products.OrderByDescending(p => p.Name).ToList();
                case SortOptions.Recommended:
                    return await this.GetReccomendedProducts();
            }

            return new List<ProductModel>();
        }


        public async Task<List<ProductModel>> GetReccomendedProducts()
        {
            var histories = await this.GetReccomendedProductsFromTestApi();
            return histories.SelectMany(h => h.Products).ToList();
        }
    }
}

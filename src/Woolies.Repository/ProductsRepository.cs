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
        private ILogger _logger;

        public ProductsRepository(IWooliesTestEndpointClient httpClient, ILogger logger)
        {
            this._httpClient = httpClient;
            this._logger = logger;
        }

        private async Task<List<ProductModel>> GetProductsFromTestApi()
        {
            try
            {
                var response = await this._httpClient.HttpClient.GetAsync("products");
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductModel>>(result);
            }
            catch(HttpRequestException exception)
            {
                this._logger.LogError("Unable to complete get request to resoure {resource}", "products");
                throw exception;
            }
        }

        private async Task<List<ShopperHistoryModel>> GetReccomendedProductsFromTestApi()
        {
            try
            {
                var response = await this._httpClient.HttpClient.GetAsync("shopperHistory");
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ShopperHistoryModel>>(result);
            }
            catch(HttpRequestException exception)
            {
                this._logger.LogError("Unable to complete get request to resoure {resource}", "shopperHistory");
                throw exception;
            }
        }

        public async Task<List<ProductModel>> GetProducts(string sortOption)
        {
            var products = await this.GetProductsFromTestApi();

            switch (sortOption)
            {
                case "Low":
                    return products.OrderBy(p => p.Price).ToList();
                case "High":
                    return products.OrderByDescending(p => p.Price).ToList();
                case "Ascending":
                    return products.OrderBy(p => p.Name).ToList();
                case "Descending":
                    return products.OrderByDescending(p => p.Name).ToList();
                case "Recommended":
                    return await this.GetReccomendedProducts();
                default:
                    break;
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

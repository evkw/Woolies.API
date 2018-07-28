using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using woolies.abstractions.Repositories;
using woolies.models;

namespace woolies.repository
{
    public class ProductsRepository : IProductsRepository
    {
        private IWooliesTestEndpointClient _httpClient;

        public ProductsRepository(IWooliesTestEndpointClient httpClient)
        {
            this._httpClient = httpClient;
        }

        private async Task<List<Product>> GetProductsFromTestApi()
        {
            var response = await this._httpClient.HttpClient.GetAsync("products");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Product>>(result);
        }

        private async Task<List<ShopperHistory>> GetReccomendedProductsFromTestApi()
        {
            var response = await this._httpClient.HttpClient.GetAsync("shopperHistory");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ShopperHistory>>(result);
        }

        public async Task<List<Product>> GetProducts(string sortOption)
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

            return new List<Product>();
        }


        public async Task<List<Product>> GetReccomendedProducts()
        {
            var histories = await this.GetReccomendedProductsFromTestApi();
            return histories.SelectMany(h => h.Products).ToList();
        }
    }
}

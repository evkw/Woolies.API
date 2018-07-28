using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using woolies.abstractions.Configuration;
using woolies.abstractions.Repositories;
using woolies.models;

namespace woolies.repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IWooliesTestConfiguration testConfig;

        private string products = @"http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products?token=a4bd6f4e-aaba-4b32-8a20-98c247590e3b";
        private string shopperHistory = @"http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=a4bd6f4e-aaba-4b32-8a20-98c247590e3b";

        public ProductsRepository(IWooliesTestConfiguration testConfig)
        {
            this.testConfig = testConfig;
        }

        private async Task<List<Product>> GetProductsFromTestApi()
        {
            var test = this.testConfig.BaseApi;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(products);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Product>>(result);
            }
        }

        private async Task<List<ShopperHistory>> GetReccomendedProductsFromTestApi()
        {
            var test = this.testConfig.BaseApi;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(shopperHistory);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<ShopperHistory>>(result);
            }
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

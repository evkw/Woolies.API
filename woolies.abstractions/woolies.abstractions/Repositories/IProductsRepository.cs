using System.Collections.Generic;
using System.Threading.Tasks;
using woolies.models;

namespace woolies.abstractions.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts(string sortOption);
    }
}

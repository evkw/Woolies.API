using System.Collections.Generic;
using System.Threading.Tasks;
using Woolies.Models;

namespace Woolies.Abstractions.Repositories
{
    public interface IProductsRepository
    {
        Task<List<ProductModel>> GetProducts(string sortOption);
    }
}

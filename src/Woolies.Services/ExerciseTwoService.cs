using System.Collections.Generic;
using System.Threading.Tasks;
using Woolies.Abstractions.Repositories;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.Services
{
    public class ExerciseTwoService : IExerciseTwoService
    {
        private readonly IProductsRepository repo;

        public ExerciseTwoService(IProductsRepository repo)
        {
            this.repo = repo;
        }

        public Task<List<ProductModel>> HandleRequest(string sortOption)
        {
            return this.repo.GetProducts(sortOption);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using woolies.abstractions.Repositories;
using woolies.abstractions.Services;
using woolies.models;

namespace woolies.services
{
    public class ExerciseTwoService : IExerciseTwoService
    {
        private readonly IProductsRepository repo;

        public ExerciseTwoService(IProductsRepository repo)
        {
            this.repo = repo;
        }

        public Task<List<Product>> HandleRequest(string sortOption)
        {
            return this.repo.GetProducts(sortOption);
        }
    }
}

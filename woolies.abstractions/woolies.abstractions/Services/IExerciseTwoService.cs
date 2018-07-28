using System.Collections.Generic;
using System.Threading.Tasks;
using woolies.models;

namespace woolies.abstractions.Services
{
    public interface IExerciseTwoService
    {
        Task<List<Product>> HandleRequest(string sortOption);
    }
}

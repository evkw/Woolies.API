using System.Collections.Generic;
using System.Threading.Tasks;
using Woolies.Models;

namespace Woolies.Abstractions.Services
{
    public interface IExerciseTwoService
    {
        Task<List<ProductModel>> HandleRequest(SortOptions sortOption);
    }
}

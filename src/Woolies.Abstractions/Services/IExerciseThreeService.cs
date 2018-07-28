using System.Threading.Tasks;
using Woolies.Models;

namespace Woolies.Abstractions.Services
{
    public interface IExerciseThreeService
    {
        Task<decimal> GetApiCalculatedTotal(TrolleyCalculatorRequest request);
    }
}

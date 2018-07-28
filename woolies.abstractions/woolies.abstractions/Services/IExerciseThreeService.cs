using System.Threading.Tasks;
using woolies.models;

namespace woolies.abstractions.Services
{
    public interface IExerciseThreeService
    {
        Task<decimal> GetApiCalculatedTotal(TrolleyCalculatorRequest request);

        decimal CalculateTotal(TrolleyCalculatorRequest request);
    }
}

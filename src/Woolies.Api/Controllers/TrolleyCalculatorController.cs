using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.api.Controllers
{
    [Route("api/trolleyCalculator")]
    public class TrolleyCalculatorController : Controller
    {
        [HttpPost]
        public async Task<decimal> Sort([FromServices]IExerciseThreeService service, [FromBody]TrolleyCalculatorRequest request)
        {
            return await service.GetApiCalculatedTotal(request);
        }
    }
}
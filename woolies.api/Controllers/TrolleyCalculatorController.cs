using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using woolies.abstractions.Services;
using woolies.models;

namespace woolies.api.Controllers
{
    [Route("api/[controller]")]
    public class TrolleyCalculatorController : Controller
    {
        [HttpGet]
        public async Task<decimal> Sort([FromServices]IExerciseThreeService service, [FromQuery]TrolleyCalculatorRequest request)
        {
            return await service.GetApiCalculatedTotal(request);
        }
    }
}
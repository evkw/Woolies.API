using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.api.Controllers
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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.api.Controllers
{
    [Route("api/sort")]
    public class SortController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Sort([FromServices]IExerciseTwoService service, [FromQuery]string sortOption)
        {
            SortOptions option;
            Enum.TryParse<SortOptions>(sortOption, out option);

            if(!Enum.IsDefined(typeof(SortOptions), option)) {
                return BadRequest("Unable to determine sorting option");
            }

            var result = await service.HandleRequest(option);
            return Ok(result);
        }
    }
}
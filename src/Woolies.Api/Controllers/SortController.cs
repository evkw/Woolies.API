using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<List<ProductModel>> Sort([FromServices]IExerciseTwoService service, [FromQuery]string sortOption)
        {
            return await service.HandleRequest(sortOption);
        }
    }
}
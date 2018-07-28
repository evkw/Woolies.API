using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using woolies.abstractions.Services;
using woolies.models;

namespace woolies.api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<List<Product>> Sort([FromServices]IExerciseTwoService service, [FromQuery]string sortOption)
        {
            return await service.HandleRequest(sortOption);
        }
    }
}
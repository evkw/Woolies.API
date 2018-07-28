using Microsoft.AspNetCore.Mvc;
using Woolies.Abstractions.Services;
using Woolies.Models;

namespace Woolies.api.Controllers
{
    [Route("api/answers")]
    public class AnswersController : Controller
    {
        // GET api/values
        [HttpGet("user")]
        public User Get([FromServices]IExerciseOneService service)
        {
            return service.HandleRequest();
        }
    }
}
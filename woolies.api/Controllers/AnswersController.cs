using Microsoft.AspNetCore.Mvc;
using woolies.abstractions.Services;
using woolies.models;

namespace woolies.api.Controllers
{
    [Route("api/[controller]")]
    public class AnswersController : Controller
    {
        // GET api/values
        [HttpGet("User")]
        public User Get([FromServices]IExerciseOneService service)
        {
            return service.HandleRequest();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace TestAPI.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {

        [HttpGet("{id}/{firstname}")]
        public StandardApiModel GetSomethingOther(int id, string firstname)
        {
            return new StandardApiModel()
            {
                Heading = $"Nallo {firstname}. Du wurdest unter der Nummer {id} gefunden."
            };
        }

        [HttpGet("{id}")]
        public StandardApiModel GetBookById(int id)
        {
            return new StandardApiModel()
            {
                Heading = $"Buch {id} wurde gefunden"
            };
        }
    }
}

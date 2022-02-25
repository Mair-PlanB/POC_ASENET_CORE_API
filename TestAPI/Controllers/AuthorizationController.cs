using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        public StandardApiModel CreateNewUser()
        {
            return new StandardApiModel()
            {
                Status = Status.OK,
                Heading = $"Created new user",
                Description = string.Empty
            };
        }
    }
}
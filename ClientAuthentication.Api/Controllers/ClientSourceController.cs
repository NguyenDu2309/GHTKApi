using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientAuthentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSourceController : ControllerBase
    {
        private readonly IClientSourceAuthencitationHandler _handler;

        public ClientSourceController(IClientSourceAuthencitationHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (_handler.Validate(id))
            {
                return Ok();
            }
            return Unauthorized();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientAuthentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSourceController : ControllerBase
    {
        private readonly ILogger<ClientSourceController> _logger;
        private readonly IClientSourceAuthencitationHandler _handler;

        public ClientSourceController(IClientSourceAuthencitationHandler handler, ILogger<ClientSourceController> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            _logger.LogInformation($"Authenticating client id: {id}");

            if (_handler.Validate(id))
            {
                _logger.LogInformation("Client authenticated successfully.");
                return Ok();
            }
            _logger.LogWarning("Client authentication failed.");
            return Unauthorized();
        }
    }
}

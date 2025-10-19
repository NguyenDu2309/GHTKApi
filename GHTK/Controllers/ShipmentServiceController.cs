using GHTK.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GHTK.Api.Controllers
{
    [ApiController]
    [Route("/services/shipment")]
    public class ShipmentServiceController : Controller
    {
        public ShipmentServiceController()
        {
        }

        [HttpPost]
        [Route("order")]
        [Authorize]
        public IActionResult CreateOrder([FromBody] CreateOrder shipment)
        {
            return Ok();
        }
    }
}

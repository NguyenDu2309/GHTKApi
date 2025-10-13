using GHTK.Models;
using Microsoft.AspNetCore.Mvc;

namespace GHTK.Controllers
{
    [ApiController]
    [Route("/services/shipment")]
    public class ShipmentServiceController : Controller
    {
        public ShipmentServiceController()
        {
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrder shipment)
        {
            return Ok();
        }
    }
}

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
        public IActionResult SubmitOrder([FromBody] SubmitOrderModel order)
        {
            return Ok();
        }
        [HttpGet]
        [Route("v2/{id}")]
        [Authorize]

        public IActionResult GetOrderStatus(int id)
        {
            return Ok();
        }
        [HttpPost]
        [Route("cancel/{id}")]
        [Authorize]

        public IActionResult CancelOrderStatus(int id)
        {
            return Ok();
        }
    }
}

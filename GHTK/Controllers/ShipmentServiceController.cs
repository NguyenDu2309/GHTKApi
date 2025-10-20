using Ghtk.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GHTK.Api.Controllers
{
    [ApiController]
    [Route("/services/shipment")]
    public class ShipmentServiceController(ILogger<ShipmentServiceController> logger) : Controller
    {
        private readonly ILogger<ShipmentServiceController> _logger = logger;

        [HttpPost]
        [Route("order")]
        [Authorize]
        public IActionResult SubmitOrder([FromBody] SubmitOrderRequest order)
        {
            _logger.LogInformation("SubmitOrder called");
         
            var response = new SubmitOrderResponse
            {
                Success = true,
                Order = new SubmitOrderResponseOrder
                {
                    PartnerId = order.Order.Id,
                    Area = 1,
                    Fee = 30000,
                    InsuranceFee = 0,
                    TrackingId = "TRACK123456",
                    EstimatedPickTime = DateTime.UtcNow.AddHours(2).ToString("o"),
                    EstimatedDeliverTime = DateTime.UtcNow.AddDays(2).ToString("o"),
                    Products = order.Products,
                    StatusId = 1
                }
            };
            return Ok(response);
        }



        [HttpGet]
        [Route("v2/{id}")]
        [Authorize]

        public IActionResult GetOrderStatus(int id)
        {
            _logger.LogInformation($"GetOrder called with id {id}", id);
            var result = new GetOrderStatusResponse
            {
                Success = true,
                Order = new StatusOrder
                {
                    LabelId = "LABEL123456",
                    PartnerId = id.ToString(),
                    Status = 3,
                    StatusText = "In Transit",
                    Created = DateTimeOffset.UtcNow.AddDays(-1),
                    Modified = DateTimeOffset.UtcNow,
                    Message = "Your order is on the way.",
                    PickDate = DateTimeOffset.UtcNow.AddDays(-1),
                    DeliverDate = DateTimeOffset.UtcNow.AddDays(2),
                    CustomerFullname = "John Doe",
                    CustomerTel = "0123456789",
                    Address = "123 Main St, City, Country",
                    StorageDay = 0,
                    ShipMoney = 30000,
                    Insurance = 0,
                    Value = 500000
                }
            };

            return Ok(result);
        }
        [HttpPost]
        [Route("cancel/{id}")]
        [Authorize]

        public IActionResult CancelOrderStatus(int id)
        {
            _logger.LogInformation($"CancelOrder called with id {id}", id);

            var result = new ApiResult
            {
                Success = true,
                Message = "Order cancelled successfully."

            };
            return Ok(result);
        }
    }
}

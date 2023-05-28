using AnyCompany.Domain.Models;
using AnyCompany.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AnyCompany.Api.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrderAsync([FromBody] Order order, int cutomerId)
        {
            var result = await orderService.PlaceOrderAsync(order, cutomerId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
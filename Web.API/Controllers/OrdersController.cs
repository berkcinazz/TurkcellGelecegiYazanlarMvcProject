using Business.Abstract;
using Entities.Dtos.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("add-order")]
        public IActionResult AddOrder(OrderForAddDto order)
        {
            var result = _orderService.AddOrder(order);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("cancel-order")]
        public IActionResult CancelOrder(string orderCode)
        {
            var result = _orderService.CancelOrder(orderCode);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-order-by-order-code")]
        public IActionResult GetOrderByOrderCode(string orderCode)
        {
            var result = _orderService.GetOrderByOrderCode(orderCode);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}

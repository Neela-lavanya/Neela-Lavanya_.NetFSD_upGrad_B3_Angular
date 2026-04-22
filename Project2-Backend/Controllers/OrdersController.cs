using BackendProject.DTOs;
using BackendProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        // CREATE ORDER
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid order");

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _service.CreateOrderAsync(dto, userId);

            return Ok(result);
        }

        // GET ALL ORDERS
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        // GET ORDER BY ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _service.GetByIdAsync(id);

            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }
    }
}
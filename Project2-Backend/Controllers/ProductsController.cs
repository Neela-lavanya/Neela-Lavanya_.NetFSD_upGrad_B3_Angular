using BackendProject.DTOs;
using BackendProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET all products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET product by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        // ADD product (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(dto);

            return Ok("Product added successfully");
        }

        // UPDATE product
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var existing = await _service.GetByIdAsync(id);

            if (existing == null)
                return NotFound("Product not found");

            await _service.UpdateAsync(id, dto);

            return Ok("Product updated successfully");
        }

        // DELETE product
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existing = await _service.GetByIdAsync(id);

            if (existing == null)
                return NotFound("Product not found");

            await _service.DeleteAsync(id);

            return Ok("Product deleted successfully");
        }
    }
}

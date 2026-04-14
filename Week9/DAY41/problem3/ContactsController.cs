using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;
using WebApplication11.Data;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        // GET (Rate Limited)
        [EnableRateLimiting("fixed")]
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        // POST (Add Contact)
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest("Invalid data");

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return Ok(contact);
        }
    }
}
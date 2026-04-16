using ContactService.Models;
using ContactService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
            => Ok(await _service.Add(contact));

        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
            => Ok(await _service.Update(contact));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _service.Delete(id));
    }
}

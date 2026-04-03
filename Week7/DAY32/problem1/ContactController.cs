using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        // Constructor Injection
        public ContactController(IContactService service)
        {
            _service = service;
        }

        // Show all contacts
        public IActionResult ShowContacts()
        {
            var list = _service.GetAllContacts();
            return View(list);
        }

        // Search by ID
        public IActionResult GetContactById(int id)
        {
            var contact = _service.GetContactById(id);
            return View(contact);
        }

        // GET Add
        public IActionResult AddContact()
        {
            return View();
        }

        // POST Add
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _service.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication5.Models;

namespace WebApplication26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Anji", LastName = "Kumar", EmailId = "anji@gmail.com", MobileNo = 9876543210, Designation = "Developer", CompanyId = 1, DepartmentId = 1 },
            new ContactInfo { ContactId = 2, FirstName = "Ravi", LastName = "Teja", EmailId = "ravi@gmail.com", MobileNo = 9123456780, Designation = "Tester", CompanyId = 1, DepartmentId = 2 }
        };


        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.Find(c => c.ContactId == id);

            if (contact == null)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            contact.ContactId = contacts.Count + 1;
            contacts.Add(contact);

            return Ok(new
            {
                contact,
                status = "New contact added successfully!"
            });
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactInfo contact)
        {
            var Contact = contacts.Find(c => c.ContactId == id);

            if (Contact == null)
                return NotFound("Contact not found");

            Contact.FirstName = contact.FirstName;
            Contact.LastName = contact.LastName;
            Contact.EmailId = contact.EmailId;
            Contact.MobileNo = contact.MobileNo;
            Contact.Designation = contact.Designation;
            Contact.CompanyId = contact.CompanyId;
            Contact.DepartmentId = contact.DepartmentId;

            return Ok(new
            {
                updatedContact = Contact,
                status = "Contact updated successfully!"
            });
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = contacts.Find(c => c.ContactId == id);

            if (contact == null)
                return NotFound("Contact not found");

            contacts.Remove(contact);

            return Ok(new
            {
                contact,
                status = "Contact deleted successfully!"
            });
        }
    }

}



using System.Collections.Generic;
using System.Linq;
using WebApplication12.Models;

namespace WebApplication12.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existing = GetById(contact.Id);

            if (existing != null)
            {
                existing.Name = contact.Name;
                existing.Email = contact.Email;
                existing.Phone = contact.Phone;
            }
        }

        public void Delete(int id)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
    }
}

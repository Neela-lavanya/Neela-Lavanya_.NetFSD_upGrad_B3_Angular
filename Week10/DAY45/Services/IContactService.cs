using System.Collections.Generic;
using WebApplication12.Models;

namespace WebApplication12.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
    }
}

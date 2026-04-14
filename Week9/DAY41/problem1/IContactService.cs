using WebApplication9.Models;

namespace WebApplication9.services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}

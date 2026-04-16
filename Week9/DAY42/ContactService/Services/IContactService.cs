using ContactService.Models;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact?> GetById(int id);
        Task<Contact> Add(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<bool> Delete(int id);
    }
}

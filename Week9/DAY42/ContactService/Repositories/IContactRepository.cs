using ContactService.Models;

namespace ContactService.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact?> GetById(int id);
        Task<Contact> Add(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<bool> Delete(int id);
    }
}

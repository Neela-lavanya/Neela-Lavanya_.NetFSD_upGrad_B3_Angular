using WebApplication5.Models;

namespace WebApplication5.repositories
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task<ContactInfo> AddAsync(ContactInfo contact);
        Task<bool> UpdateAsync(int id, ContactInfo contact);
        Task<bool> DeleteAsync(int id);
    }
}

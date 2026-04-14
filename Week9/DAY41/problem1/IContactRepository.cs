using WebApplication9.Models;

namespace WebApplication9.repositories
{
    public interface IContactRepository
    {

        List<Contact> GetAll();
        Contact GetById(int id);
    }
}

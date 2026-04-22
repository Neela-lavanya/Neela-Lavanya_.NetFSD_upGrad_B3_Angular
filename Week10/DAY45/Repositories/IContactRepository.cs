using System.Collections.Generic;
using WebApplication12.Models;

namespace WebApplication12.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
        List<Contact> GetAll();
        Contact? GetById(int id);
    }
}

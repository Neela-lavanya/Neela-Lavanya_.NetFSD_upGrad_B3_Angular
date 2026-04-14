using WebApplication9.Models;

namespace WebApplication9.repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new()
        {
            new Contact { Id = 1, Name = "Anji", Email = "anji@test.com", Phone = "9999999999" },
            new Contact { Id = 2, Name = "Ravi", Email = "ravi@test.com", Phone = "8888888888" }
        };

        public List<Contact> GetAll()
        {
            Console.WriteLine("Fetching ALL contacts from Repository (DB simulation)");
            return _contacts;
        }

        public Contact GetById(int id)
        {
            Console.WriteLine($"Fetching Contact {id} from Repository (DB simulation)");
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
    }

}

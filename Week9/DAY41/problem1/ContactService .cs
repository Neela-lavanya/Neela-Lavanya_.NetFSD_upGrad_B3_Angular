using Microsoft.Extensions.Caching.Memory;
using WebApplication9.Models;
using WebApplication9.repositories;

namespace WebApplication9.services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        private const string ContactListKey = "contact_list";

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            if (_cache.TryGetValue(ContactListKey, out List<Contact> cachedContacts))
            {
                Console.WriteLine("Fetching ALL contacts from CACHE");
                return cachedContacts;
            }

            var contacts = _repo.GetAll();

            _cache.Set(ContactListKey, contacts, TimeSpan.FromSeconds(60));

            Console.WriteLine("Caching ALL contacts for 60 seconds");
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (_cache.TryGetValue(cacheKey, out Contact cachedContact))
            {
                Console.WriteLine($"Fetching Contact {id} from CACHE");
                return cachedContact;
            }

            var contact = _repo.GetById(id);

            if (contact == null)
                return null;

            _cache.Set(cacheKey, contact, TimeSpan.FromSeconds(60));

            Console.WriteLine($"Caching Contact {id} for 60 seconds");
            return contact;
        }
    }
}

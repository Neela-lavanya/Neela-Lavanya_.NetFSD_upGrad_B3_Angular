using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAll()
            => await _context.Contacts.ToListAsync();

        public async Task<Contact?> GetById(int id)
            => await _context.Contacts.FindAsync(id);

        public async Task<Contact> Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Contacts.FindAsync(id);
            if (data == null) return false;

            _context.Contacts.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

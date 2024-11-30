using Microsoft.EntityFrameworkCore;
using WAD_contactManager_00016328.Data;
using WAD_contactManager_00016328.Models;

namespace WAD_contactManager_00016328.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.Include(c => c.Group).ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.Include(c => c.Group).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}

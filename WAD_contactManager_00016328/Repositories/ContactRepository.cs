using Microsoft.EntityFrameworkCore;
using WAD_contactManager_00016328.Data;
using WAD_contactManager_00016328.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WAD_contactManager_00016328.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Contact entity)
        {
            _context.Contacts.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var removeItem = await _context.Contacts.FindAsync(id);
            if (removeItem != null)
            {
                _context.Contacts.Remove(removeItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}

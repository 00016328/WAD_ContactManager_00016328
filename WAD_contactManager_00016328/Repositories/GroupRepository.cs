using Microsoft.EntityFrameworkCore;
using WAD_contactManager_00016328.Data;
using WAD_contactManager_00016328.Models;

namespace WAD_contactManager_00016328.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}

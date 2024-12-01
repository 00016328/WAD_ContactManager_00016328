﻿using Microsoft.EntityFrameworkCore;
using WAD_contactManager_00016328.Data;
using WAD_contactManager_00016328.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WAD_contactManager_00016328.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Group entity)
        {
            await _context.Groups.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
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

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups
                .Include(g => g.Contacts)
                .ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups
                .Include(g => g.Contacts)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
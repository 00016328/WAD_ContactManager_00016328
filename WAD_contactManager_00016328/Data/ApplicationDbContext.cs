using Microsoft.EntityFrameworkCore;
using WAD_contactManager_00016328.Models;

namespace WAD_contactManager_00016328.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}

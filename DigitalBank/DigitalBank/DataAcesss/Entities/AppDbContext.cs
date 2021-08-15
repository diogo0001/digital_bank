using Microsoft.EntityFrameworkCore;

namespace DigitalBank.DataAcesss.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User{ get; set; }

        public DbSet<Account> Account { get; set; }
    }
}

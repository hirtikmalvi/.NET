using Microsoft.EntityFrameworkCore;

namespace JwtDemo.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options):base(options){}
        public DbSet<User> Users { get; set; }
    }
}

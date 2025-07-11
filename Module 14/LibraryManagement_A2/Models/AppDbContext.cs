using Microsoft.EntityFrameworkCore;

namespace LibraryManagement_A2.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(x => x.Id);

            modelBuilder.Entity<Book>().Property(x => x.Title).IsRequired();

            modelBuilder.Entity<Book>().Property(x => x.Author).IsRequired();

            modelBuilder.Entity<Book>().ToTable(t => t.HasCheckConstraint("CK_Book_Price_Positive", "[Price] > 0"));
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem_A1.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(120);

            modelBuilder.Entity<Student>().Property(s => s.Age).IsRequired();

            modelBuilder.Entity<Student>().Property(s => s.Grade).IsRequired();
        }
    }
}

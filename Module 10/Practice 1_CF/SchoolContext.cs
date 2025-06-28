using Microsoft.EntityFrameworkCore;

namespace Practice_1_CF
{
    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QBJ7RSI\\SQLEXPRESS;Database=NewSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;"); 
        }

    }
}

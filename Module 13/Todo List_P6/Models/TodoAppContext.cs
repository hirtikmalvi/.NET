using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace Todo_List_P6.Models
{
    public class TodoAppContext: DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoAppContext(DbContextOptions<TodoAppContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(t => t.Title).IsRequired().HasMaxLength(100).IsUnicode(true);
            modelBuilder.Entity<TodoItem>().Property(t => t.isCompleted).HasDefaultValue(false);

            modelBuilder.Entity<TodoItem>().HasData(new TodoItem { Id = 1, Title = "Buy groceries", Date = new DateTime(2025, 7, 10), isCompleted = false },
            new TodoItem { Id = 2, Title = "Finish project report", Date = new DateTime(2025, 7, 12), isCompleted = false },
            new TodoItem { Id = 3, Title = "Call mom", Date = new DateTime(2025, 7, 8), isCompleted = true },
            new TodoItem { Id = 4, Title = "Go for a run", Date = new DateTime(2025, 7, 9), isCompleted = false },
            new TodoItem { Id = 5, Title = "Read a book", Date = new DateTime(2025, 7, 11), isCompleted = false });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Practice_2
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QBJ7RSI\\SQLEXPRESS;Database=ShopDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                                        new Category { CategoryId = 1, CategoryName = "Electronics" },
                                        new Category { CategoryId = 2, CategoryName = "Clothing" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Phone",
                    Description = "Latest smartphone",
                    Price = 500,
                    CategoryId = 1
                },
        new Product
        {
            ProductId = 2,
            ProductName = "Laptop",
            Description = "Gaming laptop",
            Price = 1500,
            CategoryId = 1
        },
        new Product
        {
            ProductId = 3,
            ProductName = "T-Shirt",
            Description = "Cotton T-Shirt",
            Price = 300,
            CategoryId = 2
        }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_3.Models
{
    public class AppDbContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QBJ7RSI\\SQLEXPRESS;Database=OnlineStoreM11A3;Trusted_Connection=True;TrustServerCertificate=True");    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics"
                },
                new Category
                {
                    Id = 2,
                    Name = "Furniture"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 1500,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Sofa",
                    Price = 800,
                    CategoryId = 2,
                }
            );

            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

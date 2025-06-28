using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Practice_2;

internal class Program
{
    private static void Main(string[] args)
    {
        var disconnectedProduct = new Product
        {
            ProductName = "Laptop"
        };
        using (var context = new AppDbContext())
        {
            if (context.Database.EnsureCreated())
            {
                Console.WriteLine($"Database has been created: {context.Database.GetDbConnection().Database}");
            }
            else
            {
                Console.WriteLine($"Database already exists: {context.Database.GetDbConnection().Database}");
            }

            //var product1 = new Product
            //{
            //    ProductName = "Maggie"
            //};
            //var product2 = new Product
            //{
            //    ProductName = "Dell Mouse"
            //};
            //context.Add<Product>( product1 );

            //var product = context.Products.First(p => p.ProductId == 1);

            //context.Products.Remove(product);

            //product.ProductName = "Yippi Noodles";
            //Console.WriteLine($"State: {context.Entry(disconnectedProduct).State}");
            //Console.WriteLine(product);

            //context.Categories.Add(new Category { CategoryName = "Home Appliances" });

            try
            {
            //    context.Products.AddRange(
            //    new Product
            //    {
            //        ProductName = "Phone",
            //        Description = "Latest smartphone",
            //        Price = 500,
            //        CategoryId = 1
            //    },
            //    new Product
            //    {
            //        ProductName = "Laptop",
            //        Description = "High-performance gaming laptop",
            //        Price = 1500,
            //        CategoryId = 1
            //    },
            //    new Product
            //    {
            //        ProductName = "T-Shirt",
            //        Description = "Cotton t-shirt",
            //        Price = 300,
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        ProductName = "Microwave",
            //        Description = "800W Microwave oven",
            //        Price = 7000,
            //        CategoryId = 5
            //    },
            //    new Product
            //    {
            //        ProductName = "Refrigerator",
            //        Description = "Double door fridge",
            //        Price = 25000,
            //        CategoryId = 5
            //    },
            //    new Product
            //    {
            //        ProductName = "Jeans",
            //        Description = "Slim fit jeans",
            //        Price = 1200,
            //        CategoryId = 2
            //    }
            //);
                //DisplayStates(context.ChangeTracker.Entries());

                //context.SaveChanges();

                //DisplayStates(context.ChangeTracker.Entries());
                var products = context.Products.ToList();
                var categories = context.Categories.ToList();
                var productsWithCategories = context.Products;

                foreach (var p in productsWithCategories)
                {
                    Console.WriteLine($"{p.Category.CategoryName} - {p.Category.CategoryId}");  
                }

                foreach (var c in context.Categories)
                {
                    Console.WriteLine($"Id: {c.CategoryId} - Name: {c.CategoryName}");
                    foreach (var p in c.Products)
                    {
                        Console.WriteLine($"\n\tId: {p.ProductId} - Name: {p.ProductName} - Description: {p.Description} - CategoryId: {p.CategoryId}");
                    }
                }
                //foreach (var p in products)
                //{
                //    Console.WriteLine($"Id: {p.ProductId} - Name: {p.ProductName} - Description: {p.Description} - CategoryId: {p.CategoryId}");
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine($"Massage: {e.InnerException.Message}");
            }
        }
    }

    static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name},State: { entry.State.ToString()}");
        }
    }
}
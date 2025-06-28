using Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
		try
		{
			Console.WriteLine("---------- Online Store ----------");
			using (var context = new AppDbContext())
			{
				//var productToAdd = new Product
				//{
				//	Name = "Keyboard",
				//	Price = 2000,
				//	CategoryId = 1,
				//};

				//context.Products.Add(productToAdd);
				//Console.WriteLine($"Product Status Before: {context.Products.Entry(productToAdd).State.ToString()}");

				//context.SaveChanges();

				//            Console.WriteLine($"Product Status After: {context.Products.Entry(productToAdd).State.ToString()}");

				//var productToUpdate = context.Products.FirstOrDefault(p => p.Name == "Laptop");

				//if (productToUpdate != null)
				//{
				//	productToUpdate.Price = 1600;
				//	Console.WriteLine("Laptop Price Updated...");
				//	context.SaveChanges();
				//}

				//var productToDelete = context.Products.FirstOrDefault(p => p.Name == "Sofa");

				//if (productToDelete != null)
				//{
				//	context.Products.Remove(productToDelete);
				//	Console.WriteLine("Sofa Product Deleted...");
				//	context.SaveChanges();
				//}

				//var product = new Product
				//{
				//	Name = "SofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofaSofa",
				//	CategoryId = 2,
				//	Price = 8000
				//};
				//context.Products.Add(product);
				//context.SaveChanges();

				var products = context.Products.Include(p => p.Category);

                foreach (var p in products)
                {
					Console.WriteLine($"ProductId: {p.Id} - Name: {p.Name} - Price: {p.Price} - Category: {p.Category.Name}");
				}

				//var phone = context.Products.FirstOrDefault(p => p.Name == "Phone");
				//var laptop = context.Products.FirstOrDefault(p => p.Name == "Laptop");

				//            var orderToAdd = new Order
				//{
				//	OrderDate = DateTime.Now,
				//	Products = new List<Product> { phone, laptop },
				//};
				//context.Orders.Add(orderToAdd);
				//context.SaveChanges();

				//var topTwoProducts = context.Products.OrderByDescending(p => p.Price).Take(2);

				//Console.WriteLine("Top Two Products: ");
				//           foreach (var p in topTwoProducts)
				//           {
				//Console.WriteLine($"ProductId: {p.Id} - Name: {p.Name} - Price: {p.Price}");
				//           }
				var prodCountInCategory = context.Products.GroupBy(p => p.CategoryId).Select(g => new
				{
					CategoryName = g.Key,
					Count = g.Count()
				});

				foreach (var g in prodCountInCategory)
				{
					Console.WriteLine($"Category: {g.CategoryName} - Count: {g.Count}");
				}

				//Console.WriteLine($"Count: {prodCountInCategory}");
            }

        }
		catch (Exception e)
		{
			Console.WriteLine($"Exception: {e.Message}");
			Console.WriteLine($"InnerException: {e.InnerException.Message}");
		}
    }
}
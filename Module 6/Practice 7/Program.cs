public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string Status { get; set; }  // e.g., "Pending", "Completed", "Shipped"
    public double TotalAmount { get; set; }
}


internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR" },
            new Employee { Id = 2, Name = "Bob", Department = "IT" },
            new Employee { Id = 3, Name = "Charlie", Department = "HR" },
            new Employee { Id = 4, Name = "Diana", Department = "Sales" },
            new Employee { Id = 5, Name = "Ethan", Department = "IT" }
        };
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Stock = 10 },
            new Product { Id = 2, Name = "TV", Category = "Electronics", Stock = 5 },
            new Product { Id = 3, Name = "Shirt", Category = "Clothing", Stock = 25 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Stock = 15 },
            new Product { Id = 5, Name = "Blender", Category = "Kitchen", Stock = 7 }
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Alice", Country = "USA" },
            new Customer { Id = 2, Name = "Bob", Country = "UK" },
            new Customer { Id = 3, Name = "Charlie", Country = "USA" },
            new Customer { Id = 4, Name = "Diana", Country = "Canada" },
            new Customer { Id = 5, Name = "Ethan", Country = "UK" }
        };

        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, Status = "Completed", TotalAmount = 250.00 },
            new Order { Id = 2, Status = "Pending", TotalAmount = 100.00 },
            new Order { Id = 3, Status = "Completed", TotalAmount = 150.00 },
            new Order { Id = 4, Status = "Shipped", TotalAmount = 300.00 },
            new Order { Id = 5, Status = "Pending", TotalAmount = 75.00 }
        };


        // 1.	Use GroupBy to group a list of employees by their department and count the number of employees in each department.
        var groupedEmps = employees.GroupBy(e => e.Department);

        foreach (var item in groupedEmps)
        {
            Console.WriteLine($"Department: {item.Key}, Count: {item.Count()}");
        }

        // 2.	Write a LINQ query to group a collection of products by their categories and calculate the total stock for each category.
        var groupedProdsByCat = products.GroupBy(p => p.Category).Select(p => new
        {
            Category = p.Key,
            TotalStock = p.Sum(s => s.Stock)
        });
        Console.WriteLine("\nProducts Stock Category Wise:");
        foreach (var product in groupedProdsByCat)
        {
            Console.WriteLine($"Category: {product.Category}, Count: {product.TotalStock}");
        }

        // 3.	Implement a query using ToLookup to group customers by their country and retrieve all customers from a specific country.
        var groupedCust = customers.ToLookup(c => c.Country).Where(c => c.Key == "USA");
        foreach (var c in groupedCust)
        {
            Console.WriteLine($"\nCountry: {c.Key}");
            foreach (var item in c)
            {
                Console.WriteLine($"CustomerName: {item.Name}");
            }
        }

        // 4.	Use GroupBy to group a list of words by their length and sort the groups by the length of the words.
        List<string> words = new List<string>
        {
            "apple", "banana", "cherry", "date", "fig", "grape", "kiwi"
        };
        var groupedWords = words.GroupBy(w => w.Length).OrderBy(x => x.Key);

        foreach (var g in groupedWords)
        {
            Console.WriteLine($"\nLength: {g.Key}");
            foreach (var item in g)
            {
                Console.WriteLine($"Word: {item}");
            }
        }
        // 5.	Implement a LINQ query to group orders by their status and find the total revenue for each status.
        var groupedOrders = orders.GroupBy(o => o.Status).Select(g => new
        {
            Status = g.Key,
            TotalRevenue = g.Sum(o => o.TotalAmount)
        });

        foreach (var group in groupedOrders)
        {
            Console.WriteLine($"Status: {group.Status}, Revenue: {group.TotalRevenue}");
        }
    }
}
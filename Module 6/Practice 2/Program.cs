public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; } 
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
}

public class OrderDetail
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Age = 28 },
            new Employee { Id = 2, Name = "Bob", Age = 22 },
            new Employee { Id = 3, Name = "Charlie", Age = 35 },
            new Employee { Id = 4, Name = "David", Age = 30 },
            new Employee { Id = 5, Name = "Eve", Age = 40 }
        };

        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Laptop", Stock = 10 },
            new Product { ProductId = 2, Name = "Mouse", Stock = 0 },
            new Product { ProductId = 3, Name = "Keyboard", Stock = 5 },
            new Product { ProductId = 4, Name = "Monitor", Stock = 0 }
        };

        List<string> words = new List<string>
        {
            "Apple", "Ant", "Ball", "Bat", "Cat", "Cup", "Cow", "Dog", "Doll", "Duck"
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Alice" },
            new Customer { CustomerId = 2, Name = "Bob" },
            new Customer { CustomerId = 3, Name = "Charlie" },
        };

        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 101, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-2), Amount = 1500 },
            new Order { OrderId = 102, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-10), Amount = 2200 },
            new Order { OrderId = 103, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-40), Amount = 1200 },
            new Order { OrderId = 104, CustomerId = 3, OrderDate = DateTime.Now.AddDays(-5), Amount = 1800 },
            new Order { OrderId = 105, CustomerId = 2, OrderDate = DateTime.Now.AddMonths(-2), Amount = 900 },
        };

        List<OrderDetail> orderDetails = new List<OrderDetail>
        {
            new OrderDetail { OrderId = 1, ProductName = "Laptop", Quantity = 2 },
            new OrderDetail { OrderId = 1, ProductName = "Mouse", Quantity = 3 },
            new OrderDetail { OrderId = 2, ProductName = "Laptop", Quantity = 1 },
            new OrderDetail { OrderId = 3, ProductName = "Mouse", Quantity = 2 },
            new OrderDetail { OrderId = 4, ProductName = "Keyboard", Quantity = 5 }
        };

        // 1. Write a LINQ query to retrieve employees whose age is between 25 and 35, sorted by their names.
        var emps = employees.Where(e => e.Age >= 25 && e.Age <= 35).OrderBy(e => e.Name);
        Console.WriteLine("\nEmployees Age Between 25 and 35 and sorted by names: ");
        foreach (var e in emps)
        {
            Console.WriteLine($"ID: {e.Id}, Name: {e.Name}, Age: {e.Age}");
        }

        // 2. Using LINQ, find all products that are out of stock from a product list.
        var outOfStockProducts = products.Where(p => p.Stock == 0).ToList();
        Console.WriteLine($"\nOut of Stock Products: {string.Join(", ", outOfStockProducts.Select(p => p.ProductId))}\n");

        // 3. Implement a query to group a collection of words by their first letter and count how many words start with each letter.
        var firstLetters = words.Select(w => w[0].ToString().ToLower()).Distinct().ToList();

        var groupedWords = firstLetters.GroupJoin(words,
            f => char.ToLower(f[0]),
            w => char.ToLower(w[0]), 
            (first, wordGroup) => new { FirstLetter = first, Words = wordGroup });
      
        Console.WriteLine("\nGrouped Words By First Letter");
        foreach (var group in groupedWords)
        {
            Console.WriteLine($"Letter: {group.FirstLetter}, Words: [{string.Join(", ", group.Words)}]");
        }

        // 4. Create a LINQ query to find customers who placed orders in the last month, sorted by order date.
        var lastMonthCostumers = customers.GroupJoin(orders, c => c.CustomerId, o => o.CustomerId, (customer, orderGroup) => new
        {
            Customer = customer,
            OrderGroup = orderGroup.Where(o => o.OrderDate >= DateTime.Now.AddMonths(-1)).OrderBy(o => o.OrderDate),
        });
        Console.WriteLine("\nCustomers Who placed order last month");

        foreach (var group in lastMonthCostumers)
        {
            Console.WriteLine($"CustomerID: {group.Customer.CustomerId}, CustomerName: {group.Customer.Name}");

            foreach (var order in group.OrderGroup)
            {
                Console.WriteLine($"\t OrderID: {order.OrderId} - OrderDate: {order.OrderDate}");
            }
        }

        // 5. Write a query to calculate the total quantity of each product sold from an order detail collection.
        var totalQuantityOfEachProduct =
            orderDetails.GroupBy(o => o.ProductName);

        Console.WriteLine("\n---- Order Details ----");

        foreach (var item in totalQuantityOfEachProduct )
        {
            Console.WriteLine($"Item: {item.Key}, Count: {item.Count()}");
        }
    }
}
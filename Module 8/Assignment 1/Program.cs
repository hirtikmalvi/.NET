using System.Threading.Tasks;
using Assignment_1;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public bool IsPremium { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}

public class ShippingInfo
{
    public int ShippingId { get; set; }
    public string ShippingMethod { get; set; }
    public decimal ShippingCost { get; set; }
}


internal class Program
{
    public static async Task ProcessOrderAsync(Order order, Customer customer, Product product, ShippingInfo shippingInfo)
    {
        Console.WriteLine("Checking product is in stock...");
        await Task.Delay(1000);
        if (product.IsInStock())
        {
            Console.WriteLine("Product is in stock...");
            await Task.Delay(1000);
            Console.WriteLine("Calculating Tax...");
            decimal total = order.CalculateTotal(product, customer);
            Console.WriteLine($"Total Without Tax:  {total}");

            await Task.Delay(1000);

            decimal tax = shippingInfo.ApplyShippingCost();
            Console.WriteLine($"Tax:  {tax}");

            Console.WriteLine($"Creating Invoice....");

            await Task.Delay(1000);

            Console.WriteLine($"Invoice: OrderID: {order.OrderId}, Date: {order.OrderDate.ToFormattedDate()}, Product: {product.Name}, Price: {product.Price}, Tax: {tax}, Total: {total + tax}, Discount Applied {(customer.IsPremium ? "Discount Applied" : "No Discount")}");

        }

        else
        {
            Console.WriteLine("Product is out of stock.");
        }
    }
    private static async Task Main(string[] args)
    {
        var customer = new Customer { CustomerId = 1, Name = "Alice Johnson", IsPremium = true };


        var product = new Product { ProductId = 1, Name = "Laptop", Price = 750.00m, Stock = 12 };

        var order = new Order { OrderId = 1, CustomerId = 1, ProductId = 1, Quantity = 1, OrderDate = DateTime.Now.AddDays(-10) };

        var shippingInfo = new ShippingInfo { ShippingId = 1, ShippingMethod = "Standard", ShippingCost = 5.00m };

        ProcessOrderAsync(order, customer, product, shippingInfo);      
        Console.ReadKey();
    }
}
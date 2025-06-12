using Practice_5;

public class Product
{
    public string Name { get; set; }
    public double Amount { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string email1 = "hirtik.malvi@gmail.com";
        string email2 = "hirtik.malvigmailcom";
        Console.WriteLine($"Email {email1} is Valid? {email1.isValidEmail()}");
        Console.WriteLine($"Email {email2} is Valid? {email2.isValidEmail()}");

        List<Product> products = new List<Product>()
        {
            new Product { Name = "Maggie", Amount = 100 },
            new Product { Name = "Car", Amount = 200 },
            new Product { Name = "Bike", Amount = 2000 },
        };
        Console.WriteLine($"Average: {products.AveragePrice()}");
    }
}
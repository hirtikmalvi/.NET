using Newtonsoft.Json;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
public class Item
{
    public string ItemName { get; set; }
    public int Quantity { get; set; }
}
public class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public List<Item> Items { get; set; }
}


internal class Program
{
    private static void Main(string[] args)
    {
        var person = new Person
        {
            Name = "John Doe",
            Age = 30
        };
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99 },
            new Product { Id = 2, Name = "Mouse", Price = 19.99 }
        };
        string jsonPerson = "{\"Name\":\"Alice\",\"Age\":25}";
        string jsonArray = "[{\"Id\":1,\"Name\":\"Pen\",\"Price\":1.5},{\"Id\":2,\"Name\":\"Notebook\",\"Price\":3.0}]";

        var order = new Order
        {
            OrderId = 1001,
            Customer = "Charlie",
            Items = new List<Item>
            {
                new Item { ItemName = "Book", Quantity = 2 },
                new Item { ItemName = "Pencil", Quantity = 5 }
            }
        };

        var personJson = JsonConvert.SerializeObject(person);
        Console.WriteLine($"1. Serialised Person Json: \n{personJson}");

        var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);
        Console.WriteLine($"2. Serialised Products Json: \n{productsJson}");

        var personDeserialize = JsonConvert.DeserializeObject<Person>(personJson);
        Console.WriteLine($"3. Person Object: \nName: {personDeserialize.Name}, Age: {personDeserialize.Age}");

        var productsDeserialize = JsonConvert.DeserializeObject<List<Product>>(productsJson);

        Console.WriteLine(productsDeserialize.Aggregate("4. Products: ", (str, p) => str += $"\n\tID: {p.Id} - Name: {p.Name}"));

        var nestedObj = JsonConvert.SerializeObject(order, Formatting.Indented);
        Console.WriteLine($"5. Nested Objects In JSON Format: \n{nestedObj}");
    }
}
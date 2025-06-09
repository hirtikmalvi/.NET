public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "Alice", Age = 22 },
            new Person { Id = 2, Name = "Bob", Age = 35 },
            new Person { Id = 3, Name = "Charlie", Age = 28 },
            new Person { Id = 4, Name = "Diana", Age = 41 },
            new Person { Id = 5, Name = "Ethan", Age = 18 },
            new Person { Id = 6, Name = "Fiona", Age = 30 }
        };
        
        Func<Person, bool> condition = null;

        condition = (p) => p.Age > 30;
        var res = people.Where(condition).ToList();
        Console.WriteLine($"Records after satisfing Condition: ");
        foreach (var item in res)
        {
            Console.WriteLine($"ID: {item.Id} - Name: {item.Name} - Age: {item.Age}");
        }

        condition = (p) => p.Name.Contains("i");
        res = people.Where(condition).ToList();
        Console.WriteLine($"Records after satisfing Condition: ");
        foreach (var item in res)
        {
            Console.WriteLine($"ID: {item.Id} - Name: {item.Name} - Age: {item.Age}");
        }
    }
}
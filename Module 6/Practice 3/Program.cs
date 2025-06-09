public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Grade { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {

        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new Employee { Id = 2, Name = "Bob", Email = "bob@example.com" },
            new Employee { Id = 3, Name = "Charlie", Email = "charlie@example.com" }
        };

        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Riya", Grade = 88 },
            new Student { Id = 2, Name = "Arjun", Grade = 91 },
            new Student { Id = 3, Name = "Simran", Grade = 75 },
            new Student { Id = 4, Name = "Hirtik", Grade = 90 }
        };


        List<Person> people = new List<Person>
        {
            new Person { Name = "Vikram", Age = 28 },
            new Person { Name = "Priya", Age = 34 },
            new Person { Name = "Nitin", Age = 42 },
            new Person { Name = "Kavita", Age = 29 }
        };


        List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Clean Code" },
            new Book { BookId = 2, Title = "The Pragmatic Programmer" },
            new Book { BookId = 3, Title = "Introduction to Algorithms" }
        };

        // 1.	Use Select to transform a list of employee objects into a list of their email addresses.
        var emails = employees.Select(e => e.Email).ToList();
        Console.WriteLine($"---- Employee Emails ----\n {string.Join(", ", emails)}");

        // 2.	Use FirstOrDefault to find the first student with a grade above 90, or return null if none exist.
        var studentWith90_Above = students.FirstOrDefault(s => s.Grade > 90);
        Console.WriteLine($"\nFirst Student With 90 Above: {(studentWith90_Above == null ? "No Student" : studentWith90_Above.Name)}");

        // 3.	Implement a LINQ chain using Select and Where to find the names of people aged above 30.
        var nameOfPeople = people.Where(p => p.Age > 30).Select(p => p.Name);
        Console.WriteLine($"\nName Of People Aged above 30: {string.Join(", ", nameOfPeople)}");

        // 4.	Use Aggregate to find the concatenated string of all book titles in a collection, separated by commas.
        var bookTitles = books.Select(b => b.Title).Aggregate((t1, t2) => t1 + ", " + t2);
        Console.WriteLine($"\nTitle Of All Books: {bookTitles}");

        // 5.	Use Take and Skip to implement pagination for displaying 5 records per page from a large dataset.
        var pages = Enumerable.Range(1, 100);
        var pageNo = 6;
        var perPageRecords = 5;
        var paginatedPages = pages.Skip((pageNo * perPageRecords) - perPageRecords).Take(5);

        Console.WriteLine($"\nRetrieved Pages: {string.Join(", ", paginatedPages)}");
        
    }

}
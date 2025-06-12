using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public int Age { get; set; }
    public bool IsInStock { get; set; } // For Practice 2 (All)
}
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Grade { get; set; }
    public int Age { get; set; }
}
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double PriceUSD { get; set; }
}
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
public class Order
{
    public int OrderId { get; set; }
    public string Status { get; set; } // "Pending", "Completed"
    public DateTime Date { get; set; }
}


internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000, Age = 28, IsInStock = true },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000, Age = 32, IsInStock = true },
            new Employee { Id = 3, Name = "Charlie", Department = "IT", Salary = 65000, Age = 29, IsInStock = true },
            new Employee { Id = 4, Name = "Diana", Department = "HR", Salary = 47000, Age = 26, IsInStock = true },
            new Employee { Id = 5, Name = "Eve", Department = "Sales", Salary = 55000, Age = 35, IsInStock = false },
            new Employee { Id = 6, Name = "Frank", Department = "Sales", Salary = 57000, Age = 40, IsInStock = true },
            new Employee { Id = 7, Name = "Grace", Department = "Finance", Salary = 62000, Age = 31, IsInStock = true },
        };
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John", Grade = 88, Age = 21 },
            new Student { Id = 2, Name = "Mia", Grade = 93, Age = 22 },
            new Student { Id = 3, Name = "Zara", Grade = 76, Age = 20 },
            new Student { Id = 4, Name = "Leo", Grade = 84, Age = 23 },
            new Student { Id = 5, Name = "Nina", Grade = 91, Age = 22 },
            new Student { Id = 6, Name = "Tom", Grade = 68, Age = 19 },
            new Student { Id = 7, Name = "Sara", Grade = 95, Age = 24 },
        };
        List<Product> products = new List<Product>
        {
            new Product { ProductId = 101, Name = "Laptop", PriceUSD = 999 },
            new Product { ProductId = 102, Name = "Mouse", PriceUSD = 20 },
            new Product { ProductId = 103, Name = "Keyboard", PriceUSD = 35 },
            new Product { ProductId = 104, Name = "Monitor", PriceUSD = 150 },
            new Product { ProductId = 105, Name = "Desk", PriceUSD = 120 },
            new Product { ProductId = 106, Name = "Chair", PriceUSD = 80 },
            new Product { ProductId = 107, Name = "Tablet", PriceUSD = 400 },
            new Product { ProductId = 108, Name = "Phone", PriceUSD = 850 },
        };
        List<User> users = new List<User>
        {
            new User { UserId = 1, Username = "admin", Email = "admin@example.com" },
            new User { UserId = 2, Username = "johndoe", Email = "john@example.com" },
            new User { UserId = 3, Username = "janedoe", Email = "jane@example.com" },
            new User { UserId = 4, Username = "bobsmith", Email = "bob@example.com" },
            new User { UserId = 5, Username = "alicew", Email = "alice@example.com" },
            new User { UserId = 6, Username = "charliet", Email = "charlie@example.com" },
        };
        List<string> words = new List<string>
        {
            "apple", "banana", "avocado", "cherry", "carrot", "apricot", "cabbage", "blueberry"
        };
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, Status = "Completed", Date = DateTime.Today.AddDays(-10) },
            new Order { OrderId = 2, Status = "Pending", Date = DateTime.Today.AddDays(-2) },
            new Order { OrderId = 3, Status = "Pending", Date = DateTime.Today.AddDays(-5) },
            new Order { OrderId = 4, Status = "Completed", Date = DateTime.Today.AddDays(0) },
            new Order { OrderId = 5, Status = "Completed", Date = DateTime.Today.AddDays(-3) },
            new Order { OrderId = 6, Status = "Pending", Date = DateTime.Today.AddDays(-8) },
            new Order { OrderId = 7, Status = "Completed", Date = DateTime.Today },
        };

        // Practice 1
        // 1.1. Use Select to extract only the names of employees from a list of Employee objects.
        var p1_1 = employees.Select(e => e.Name).ToList();
        //var p1_1 = from e in employees
        //       select e.Name;
        Console.WriteLine($"P1.1 Employees: {string.Join(", ", p1_1)}");

        // 1.2. Write a LINQ query to create a new list of Student objects with only Name and Age.
        var p1_2 = students.Select(s => new
        {
            s.Name,
            s.Age,
        });
        //var p1_2 = from e in employees
        //           select new { e.Name,e.Age };

        Console.WriteLine(p1_2.Aggregate("P1.2 Students With Name and Age: ", (str, s) => str += $"\n\tName: {s.Name}, Age: {s.Age}"));

        // Practice 2 – All / Any
        // 1.1 Use All to check if all products in a list are in stock.
        var p2_1 = employees.All(e => e.IsInStock);
        Console.WriteLine($"P2.1 All In Stock: {p2_1}");

        // 2.2. Use Any to verify if there is at least one student with a grade above 90.
        var p2_2 = students.Any(s => s.Grade > 90);
        Console.WriteLine($"P2.2 Any Student with 90 Above: {p2_2}");

        // Practice 3 – Contains

        // 3.1 Use Contains to check if a specific product ID exists.

        var p3_1_1op = products.Select(p => p.ProductId).Contains(101);
        var p3_1_2op = products.Select(p => p.ProductId).Contains(201);
        Console.WriteLine($"P3.1 Product with Id: {101} Exist? : {p3_1_1op}");
        Console.WriteLine($"P3.1 Product with Id: {201} Exist? : {p3_1_2op}");

        // 3.3.Use Contains to filter orders that match specific order IDs from a predefined list.
        var predefined_order_list = new List<int>() {1,2,9,50 };
        var p3_3 = orders.Where(o => predefined_order_list.Contains(o.OrderId));

        Console.WriteLine(p3_3.Aggregate("P3.3 Orders Filtered from predifined orderIds: ", (str, o) => str += $"\n\tOrder Id: {o.OrderId}"));

        // Practice 4 – Aggregate

        // 4.1 Use Aggregate to concatenate all product names into a comma - separated string.

        Console.WriteLine(products.Aggregate("P4.1 Product Names In Comma Separated String: ", (str, p) => str += $"\n\tID: {p.ProductId}, Name: {p.Name}"));

        // 4.3 Use Aggregate to find the longest word in a list.
        Console.WriteLine($"P4.3 Longest Word In a List: {words.Aggregate((longest, current) => current.Length > longest.Length ? current : longest)}");

        // Practice 5 – Average

        // 5.1 Use Average to calculate the average age of employees in a department.

        var p5_1 = employees.GroupBy(e => e.Department).Select(g => new
        {
            Department = g.Key,
            AverageAge = g.Average(e => e.Age)
        });

        //var p5_1 = from e in employees
        //           group e by e.Department
        //           into employeeGroup
        //           select new
        //           {
        //               Department = employeeGroup.Key,
        //               AverageAge = employeeGroup.Average(g => g.Age)
        //           };

        Console.WriteLine(p5_1.Aggregate($"P5.1 Average Age of Employees", (str, e) => str += $"\n\tDepartment: {e.Department}, Average Age: {e.AverageAge}"));

        // 5.2 Write a LINQ query to find the average grade of students.
        var t5_2 = students.Average(s => s.Grade);
        Console.WriteLine($"P5.2 Average of Students: {t5_2}");

        // Practice 6 – Count

        // 6.1 Use Count to find number of products priced above $50.
        var p6_1 = products.Count(p => p.PriceUSD > 50);
        Console.WriteLine($"P6.1 Number Of Products Above 50$: {p6_1}");

        // 6.3 Use Count to find how many numbers in a list are divisible by 3.
        var p6_3 = employees.Select(e => e.Id).Count(id => id % 3 == 0);
        Console.WriteLine($"P6.3 Numbers in a list are divisible by 3: {p6_3}");

        // Practice 7 – Single / SingleOrDefault

        // 7.1 Use Single to find the product with a unique ID.

        try
        {
            var p7_1 = products.Single(p => p.ProductId == 101);
            //var p7_1 = products.Single(); // Will throw exception because it will return multiple record
            Console.WriteLine($"P7.1 product with a unique ID: {p7_1.ProductId}, Name: {p7_1.Name}");
        }
        catch
        {
            Console.WriteLine("Exception At P7.1");
        }

        // 7.2 Use SingleOrDefault to retrieve a user by unique username.
        var p7_2 = users.Select(u => u.Username).SingleOrDefault(u => u == "admin", "No User Exists");
            Console.WriteLine($"P7.2 User with a unique username: Username: {p7_2}");

        // Practice 8 – DefaultIfEmpty

        // 8.1 Use DefaultIfEmpty to handle no high - priority tasks.

        var priorities = new List<string>()
        {
            "high", "low", "medium", "high", "high", "low", "medium"
        };

        var p8_1 = priorities.Where(p => p == "high").DefaultIfEmpty("Not Exists");

        // Following example returns null which is default value of string.
        //var p8_1 = priorities.Where(p => p == "high").DefaultIfEmpty();
        Console.WriteLine($"P8.1 {string.Join(", ", p8_1)}");


        // 8.4 Retrieve orders for a date and return "No Orders Found" if none exist.
        var p8_4 = orders.Where(o => o.Date.Date == new DateTime(2026, 6, 11)).DefaultIfEmpty(null);
        if (p8_4.First() == null)
        {
            Console.WriteLine("P8.4 No Order Exist");
        }

        // Practice 9 – Intersect / Union / Take / TakeWhile

        // 9.1 Use Union to combine two lists of integers(remove duplicates).

        var numList1 = new List<int>() { 1, 2, 3, 4, 4, 1 };
        var numList2 = new List<int>() { 1, 2, 5,6,7,3 };

        var p9_1 = numList1.Union(numList2).ToList();
        Console.WriteLine(p9_1.Aggregate("P9.1 Result After combined two lists: ", (str, i) => str += $"{i}, "));

        // 9.3 Use Take to retrieve first 5 students from a list.
        var p9_3 = students.Take(5);
        Console.WriteLine(p9_3.Aggregate("P9.3 Students from the list: ", (str, s) => str += $"\n\tStudentId: {s.Id}, Name: {s.Name}"));

        // Practice 12 – Let Keyword

        // 12.1 Use let to store square of a number.

        var nums = Enumerable.Range(1, 10);
        var p12_1 = from n in nums
                    let square = n * n
                    select new
                    {
                        Number = n,
                        Square = square
                    };
        Console.WriteLine(p12_1.Aggregate("P12.1 Number with Squares: ", (str, s) => str += $"\n\tNumber: {s.Number}, Square: {s.Square}"));

        // 12.3 Calculate discounted prices and filter by those above $10.
        var p12_3 = from product in products
                    let DiscountRate = 10
                    let DiscountedPrice = product.PriceUSD - (product.PriceUSD * DiscountRate / 100)
                    where DiscountedPrice > 10
                    select new
                    {
                        DiscountedPrice = DiscountedPrice,
                        Product = product
                    };
        Console.WriteLine(p12_3.Aggregate("P12.3 : Discounted prices and filter by those above $10", (str, p) => str += $"\n\t ProductId: {p.Product.ProductId}, DiscountedPrice: {p.DiscountedPrice}, Name: {p.Product.Name}"));


        // Practice 13 – Into Keyword

        // 13.1 Filter employees by department and sort by age using into.
        var v = employees.OrderBy(e => e.Age);
        var p13_1 = from e in employees
                    group e by e.Department
                    into employeeGroup
                    select new
                    {
                        Department = employeeGroup.Key,
                        Employees = from g in employeeGroup
                                    orderby g.Age
                                    select g
                    };
        Console.WriteLine("P13.1 Employees Grouped By Department and Sort by Age: ");
        foreach (var e in p13_1)
        {
            Console.WriteLine($"Deparment: {e.Department}");
            Console.WriteLine(e.Employees.Aggregate(string.Empty, (str, eg) => str += $"\n\tName: {eg.Name}, Age: {eg.Age}"));
        }
    }


}

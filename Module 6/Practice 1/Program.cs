class Employee
{
    public string EmployeeName { get; set; }
    public string JobTitle {  get; set; }
    public double Salary { get; set; }
    public string Department {  get; set; }
}

class Student
{
    public string StudentName { get; set; }
    public float Score {  get; set; }
}

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> ints = new List<int>() { 9,8,7,4,1,2,35,8,9,6,4,596,3,32,5 };

        List<Employee> employees = new List<Employee>() { new Employee { EmployeeName = "Hirtik", JobTitle = "Manager", Salary = 20000, Department = "IT" },
        new Employee { EmployeeName = "Hitesh", JobTitle = "GTE", Salary = 50000, Department = "HR" },
        new Employee { EmployeeName = "Jay", JobTitle = "Manager", Salary = 10000, Department = "Finance" },
        new Employee { EmployeeName = "Raj", JobTitle = "SDE", Salary = 10000, Department = "IT" }
        };

        var students = new List<Student>();
        students.Add(new Student { StudentName = "Hirtik", Score = 98 });
        students.Add(new Student { StudentName = "Hitesh", Score = 85 });
        students.Add(new Student { StudentName = "Hardik", Score = 95 });
        students.Add(new Student { StudentName = "Chintan", Score = 99 });
        students.Add(new Student { StudentName = "Jay", Score = 100 });

        var persons = new List<Person>()
        {
            new Person{ FirstName = "Hirtik", LastName = "Malvi" },
            new Person{ FirstName = "Hitesh", LastName = "Joshi" },
            new Person{ FirstName = "Jay", LastName = "Patel" },
        };

        // 1. Write a LINQ query to find all even numbers from a list of integers and display them in ascending order.
        var result = ints.Where(i => i % 2 == 0).OrderBy(i => i).ToList();
        Console.WriteLine($"Even Numbers Sorted in Ascending Order: {string.Join(", ", result)}");

        // 2. Create a LINQ query to calculate the average salary of employees whose job title is "Manager".
        Console.WriteLine($"Avg salary of Employees whose job title is Manager: {employees.Where(e => e.JobTitle == "Manager").Average(e => e.Salary)}");

        // 3. Using LINQ, retrieve the top 3 highest-scoring students from a list of scores.
        var topScorers = students.OrderByDescending(s => s.Score).Select(s => s.StudentName).Take(3).ToList();
        Console.WriteLine($"Top 3 highest-scoring students: {string.Join(", ", topScorers)} ");

        // 4. Implement a LINQ query to find the distinct departments in a company database.
        var distinctDepts = employees.Select(e => e.Department).Distinct().ToList();
        Console.WriteLine($"Distinct Departments: {string.Join(", ", distinctDepts)}");

        // 5. Use LINQ to create a new list of objects by projecting fields from an existing list (e.g., extract FirstName and LastName into a FullName property).
        var fullnames = persons.Select(p => new { FullName = $"{p.FirstName} {p.LastName}" });
        Console.WriteLine($"---- Fullnames ----");
        foreach (var fullname in fullnames)
        {
            Console.WriteLine($"FullName: {fullname.FullName}");
        }
    }
}
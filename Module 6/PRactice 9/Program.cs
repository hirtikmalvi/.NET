// Problem 1
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}

// Problem 2
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string ProductName { get; set; }
}

// Problem 3
public class Teacher
{
    public int TeacherId { get; set; }
    public string Name { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int TeacherId { get; set; }
}

// Problem 4
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int DepartmentId {  get; set; }
}

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int EmployeeId { get; set; }
}

// Problem 5 — Reuse Employee and Department from previous problems
public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}


internal class Program
{
    private static void Main(string[] args)
    {
        // Products and Categories
        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", CategoryId = 1 },
            new Product { ProductId = 2, ProductName = "Mouse", CategoryId = 1 },
            new Product { ProductId = 3, ProductName = "Shampoo", CategoryId = 2 },
        };

        List<Category> categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Personal Care" },
            new Category { CategoryId = 3, CategoryName = "Clothing" },
        };

        // Customers and Orders
        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 101, Name = "Alice" },
            new Customer { CustomerId = 102, Name = "Bob" },
            new Customer { CustomerId = 103, Name = "Charlie" },
        };

        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 101, ProductName = "Laptop" },
            new Order { OrderId = 2, CustomerId = 101, ProductName = "Mouse" },
            new Order { OrderId = 3, CustomerId = 103, ProductName = "Shampoo" },
        };

        // Teachers and Students
        List<Teacher> teachers = new List<Teacher>
        {
            new Teacher { TeacherId = 1, Name = "Mr. Smith" },
            new Teacher { TeacherId = 2, Name = "Ms. Johnson" },
        };

        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Aman", TeacherId = 1 },
            new Student { StudentId = 2, Name = "Sara", TeacherId = 2 },
            new Student { StudentId = 3, Name = "Kunal", TeacherId = 1 },
            new Student { StudentId = 4, Name = "Zara", TeacherId = 2 },
        };

        // Employees and Projects
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, Name = "John", DepartmentId =  1},
            new Employee { EmployeeId = 2, Name = "Emma" , DepartmentId =  2 },
            new Employee { EmployeeId = 3, Name = "Raj" , DepartmentId =  1 },
        };

        List<Project> projects = new List<Project>
        {
            new Project { ProjectId = 1, ProjectName = "Website", EmployeeId = 1 },
            new Project { ProjectId = 2, ProjectName = "App", EmployeeId = 1 },
            new Project { ProjectId = 3, ProjectName = "Cloud", EmployeeId = 2 },
        };

        // Departments and Employees
        List<Department> departments = new List<Department>
        {
            new Department { DepartmentId = 1, DepartmentName = "IT" },
            new Department { DepartmentId = 2, DepartmentName = "HR" },
        };

        List<Employee> deptEmployees = new List<Employee>
        {
            new Employee { EmployeeId = 1, Name = "John", DepartmentId = 1 },
            new Employee { EmployeeId = 2, Name = "Emma", DepartmentId = 1 },
            new Employee { EmployeeId = 3, Name = "Raj", DepartmentId = 2 },
        };

        var prodWithCat = categories.GroupJoin(products, c => c.CategoryId, p => p.CategoryId, (category, productGroup) => new
        {
            Category = category.CategoryName,
            Products = productGroup
        });

        // 1.	Use GroupJoin to group products by their categories and display the category name along with its products.
        Console.WriteLine("\nCategory wise product list ----\n");

        foreach (var pc in prodWithCat)
        {
            Console.WriteLine($"Category: {pc.Category}");
            foreach (var p in pc.Products)
            {
                Console.WriteLine($"\tName: {p.ProductName}");
            }
        }

        // 2.	Write a query to group customers with their orders using GroupJoin, displaying the customer name and their orders.
        var custWithOrders = customers.GroupJoin(orders, c => c.CustomerId, o => o.CustomerId, (customer, orderGroup) => new
        {
            CustomerId = customer.CustomerId,
            CustomerName = customer.Name,
            Orders = orderGroup
        });
        Console.WriteLine("\n---- Customer wise orders ----\n");

        foreach (var co in custWithOrders)
        {
            Console.WriteLine($"Customer ID: {co.CustomerId}, Name: {co.CustomerName}");
            foreach (var o in co.Orders)
            {
                Console.WriteLine($"\tID: {o.OrderId}, Name: {o.ProductName}");
            }
        }

        /* 3.	Implement a LINQ query to group a list of teachers with their students based on a TeacherId. */
        // Not Solving Because it is easy

        // 4.	Use GroupJoin to combine employees with their projects and calculate the number of projects each employee is handling.

        var empWithProj = employees.GroupJoin(projects, e => e.EmployeeId, p => p.EmployeeId, (employee, projectGroup) => new
        {
            Employee = employee.Name,
            Count = projectGroup.Count()
        });
        Console.WriteLine($"\n---- Employee With Project Count ----\n");
        foreach (var ep in empWithProj)
        {
            Console.WriteLine($"Employee: {ep.Employee} - Count: {ep.Count}");
        }

        // 5.	Write a LINQ query to group departments with their employees and sort the departments by the number of employees. 

        var deptWithEmps = departments.GroupJoin(employees, d => d.DepartmentId, e => e.DepartmentId, (department, employeeGroup) => new
        {
            Department = department.DepartmentName,
            Employees = employeeGroup
        }).OrderByDescending(group => group.Employees.Count());

        Console.WriteLine("\nDepartments With Employees Sorted By Employee Count ----\n");
        foreach (var group in deptWithEmps)
        {
            Console.WriteLine($"Department: {group.Department}");
            foreach (var e in group.Employees)
            {
                Console.WriteLine($"\tEmployeeName: {e.Name}");
            }
        }
    }
}
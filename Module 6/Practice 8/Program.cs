// Problem 1
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}

// Problem 2
public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

// Problem 3
public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
}

public class Grade
{
    public int StudentId { get; set; }
    public string Subject { get; set; }
    public double Score { get; set; }
}

// Problem 4
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int SupplierId { get; set; }
}

public class Supplier
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
}

// Problem 5 — Reuses Order and Customer from Problem 2


internal class Program
{
    private static void Main(string[] args)
    {
        // Employees and Departments
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, Name = "Alice", DepartmentId = 101 },
            new Employee { EmployeeId = 2, Name = "Bob", DepartmentId = 102 },
            new Employee { EmployeeId = 3, Name = "Charlie", DepartmentId = 103 },
        };

        List<Department> departments = new List<Department>
        {
            new Department { DepartmentId = 101, DepartmentName = "HR" },
            new Department { DepartmentId = 102, DepartmentName = "IT" },
            new Department { DepartmentId = 103, DepartmentName = "Finance" },
        };

        // Orders and Customers
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 201, OrderDate = new DateTime(2024, 12, 1) },
            new Order { OrderId = 2, CustomerId = 202, OrderDate = new DateTime(2025, 1, 10) },
            new Order { OrderId = 3, CustomerId = 203, OrderDate = new DateTime(2025, 2, 5) },
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 201, Name = "John" },
            new Customer { CustomerId = 202, Name = "Emma" },
            new Customer { CustomerId = 203, Name = "Liam" },
        };

        // Students and Grades
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Aman" },
            new Student { StudentId = 2, Name = "Sara" },
            new Student { StudentId = 3, Name = "Kunal" },
        };

        List<Grade> grades = new List<Grade>
        {
            new Grade { StudentId = 1, Subject = "Math", Score = 89 },
            new Grade { StudentId = 2, Subject = "Math", Score = 93 },
            new Grade { StudentId = 3, Subject = "Math", Score = 77 },
        };

        // Products and Suppliers
        List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", SupplierId = 301 },
            new Product { ProductId = 2, ProductName = "Phone", SupplierId = 302 },
            new Product { ProductId = 3, ProductName = "Tablet", SupplierId = 301 },
        };

        List<Supplier> suppliers = new List<Supplier>
        {
            new Supplier { SupplierId = 301, SupplierName = "Tech Corp" },
            new Supplier { SupplierId = 302, SupplierName = "Gadget Inc" },
        };


        // 1.	Write a LINQ query to join two lists: employees and departments, and display employee names along with their department names.
        var employeesWithDepts = employees.Join(departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new
        {
            EmployeeName = e.Name,
            DepartmentName = d.DepartmentName
        });
        Console.WriteLine("\n---- Employee With Department ----\n");
        foreach (var ed in employeesWithDepts)
        {
            Console.WriteLine($"EmployeeName: {ed.EmployeeName} - DepartmentName: {ed.DepartmentName}");
        }

        // 2.	Use Join to combine a list of orders with a list of customers based on customer ID. 

        var customerWithOrder = customers.Join(orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new
        {
            c.Name,
            c.CustomerId,
            o.OrderId,
        });

        Console.WriteLine("\n---- Customers With Orders ----\n");
        foreach (var co in customerWithOrder)
        {
            Console.WriteLine($"CustomerID: {co.CustomerId} - CustomerName: {co.Name} - OrderId: {co.OrderId}");
        }


        // 3.	Implement a query to join a list of students with their grades and display the student's name and grade.

        var studentGrades = students.Join(grades, s => s.StudentId, g => g.StudentId, (s, g) => new
        {
            s.StudentId,
            s.Name,
            g.Subject,
            g.Score
        });

        Console.WriteLine("\n---- Students With Grades ----\n");
        foreach (var sg in studentGrades)
        {
            Console.WriteLine($"Student: {sg.Name} - Subject: {sg.Subject} - Grade: {sg.Score}");
        }

        // 4.	Use Join to create a combined list of products and their suppliers based on a common field.

        var productsWithSuppliers = products.Join(suppliers, s => s.SupplierId, s => s.SupplierId, (p, s) => new { p, s });

        Console.WriteLine("\n---- Products With Suppliers ----\n");
        foreach (var ps in productsWithSuppliers)
        {
            Console.WriteLine($"Product: {ps.p.ProductName} - Supplier: {ps.s.SupplierName}");
        }

        // 5.	Write a LINQ query to join two lists and filter the result by a specific condition (e.g., orders placed after a specific date).
        var custWithOrders = customers.Join(orders.Where(o => o.OrderDate >= new DateTime(2025, 1,1)), c => c.CustomerId, o => o.CustomerId, (c, o) => new
        {
            Name = c.Name,
            OrderID = o.OrderId,
            Date = o.OrderDate,
        });
        Console.WriteLine("\n---- Orders After Specific Date (Taken Today's date by default) ----\n");
        foreach (var co in custWithOrders)
        {
            Console.WriteLine($"Name: {co.Name} - OrderID: {co.OrderID} - Date: {co.Date}");
        }
    }
}
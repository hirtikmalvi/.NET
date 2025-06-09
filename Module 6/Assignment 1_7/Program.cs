public class Employee
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public DateTime JoiningDate { get; set; }
    public string Deparment { get; set; }
}

public class Incentive
{
    public int ID { get; set; }
    public double IncentiveAmount { get; set; }
    public DateTime IncentiveDate { get; set; }
}


internal class Program
{
        public  static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {new Employee
                {
                    ID = 2, FirstName = "Michael", LastName = "Clarke", Salary = 800000,
                    JoiningDate = new DateTime(2013, 1, 1), Deparment = "Insurance"
                },
                new Employee
                {
                    ID = 1, FirstName = "John", LastName = "Abraham", Salary = 1000000,
                    JoiningDate = new DateTime(2013, 1, 1), Deparment = "Banking"
                },
                
                new Employee
                {
                    ID = 3, FirstName = "Roy", LastName = "Thomas", Salary = 700000,
                    JoiningDate = new DateTime(2013, 1, 1), Deparment = "Insurance"
                },
                new Employee
                {
                    ID = 4, FirstName = "Tom", LastName = "Jose", Salary = 600000,
                    JoiningDate = new DateTime(2013, 1, 1), Deparment = "Banking"
                },
                new Employee
                {
                    ID = 5, FirstName = "TestName2", LastName = "Lname%", Salary = 600000,
                    JoiningDate = new DateTime(2013, 1, 1), Deparment = "Services"
                }
            };

            List<Incentive> incentives = new List<Incentive>()
            {
                new Incentive { ID = 1, IncentiveAmount = 5000, IncentiveDate = new DateTime(2013, 2, 2) },
                new Incentive { ID = 2, IncentiveAmount = 10000, IncentiveDate = new DateTime(2013, 2, 4) },
                new Incentive { ID = 1, IncentiveAmount = 6000, IncentiveDate = new DateTime(2012, 1, 5) },
                new Incentive { ID = 2, IncentiveAmount = 3000, IncentiveDate = new DateTime(2012, 1, 5) }
            };

            // Assignment 2 - Get employee details from employees object whose employee name is “John” (note restrict operator)
            Console.WriteLine($"Employee Name Is John: ");
            var empJohn = employees.Where(e => e.FirstName == "John");


            foreach (var e in empJohn)
            {
                Console.WriteLine($"ID: {e.ID}, FirstName: {e.FirstName}, LastName: {e.LastName}, Department: {e.Deparment}");
            }

        // Assignment 3 - Get FIRSTNAME,LASTNAMe from employees object(note project operator)
        var names = employees.Select(e => new
        {
            e.FirstName,
            e.LastName,
        }).ToList();

        // Assignment 4 - Select FirstName, IncentiveAmount from employees and incentives object for those employees who have incentives.(join operator)

        var a4 = employees.Join(incentives, e => e.ID, i => i.ID, (e, i) => new
        {
            e.FirstName,
            i.IncentiveAmount,
            Incentive = i
        });

        // Assignment 5 - Get department wise maximum salary from employee table order by salary ascending (note group by)

        var deptWiseMaxSalary = employees.GroupBy(e => e.Deparment).Select(group => new
        {
            Deparment = group.Key,
            MaxSalary = group.Max(s => s.Salary)
        });
        Console.WriteLine($"Department Wise Max Salary: ");
        foreach (var i in deptWiseMaxSalary)
        {
            Console.WriteLine($"Department: {i.Deparment}, MaxSalary: {i.MaxSalary}");
        }

        // Assignment 6 - Select department, total salary with respect to a department from employees object where total salary greater than 800000 order by TotalSalary descending(group by having)

        var a6 = employees.GroupBy(e => e.Deparment).Select(g => new
        {
            Department = g.Key,
            TotalSalary = g.Sum(e => e.Salary)
        }).Where(r => r.TotalSalary > 800000).OrderByDescending(r => r.TotalSalary);

        Console.WriteLine("\nDepartment, Total salary with respect to a department from employees object where total salary greater than 800000 order by TotalSalary descending(group by having)");
        foreach (var e in a6)
        {
            Console.WriteLine($"Department: {e.Department}, TotalSalary: {e.TotalSalary}");
        }
    }
}
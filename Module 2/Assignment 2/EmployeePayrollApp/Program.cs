using PayrollLibrary;

internal class Program
{
    private PayrollManager payrollManager = new PayrollManager();
    public void AddEmployee()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Department: ");
        string department = Console.ReadLine();

        Console.Write("Enter Base Salary: ");
        double basicSalary = Convert.ToDouble(Console.ReadLine());

        Employee employee = new Employee(name, department, basicSalary);
        payrollManager.AddEmployee(employee);
    }

    public void ViewEmployees()
    {
        payrollManager.DisplayEmployees();
    }

    public void DiplayNetSalary()
    {
        Console.WriteLine($"| {"ID",-15} | {"Name",-25} | {"Department",-10} | {"Net Salary",-10} |");
        foreach (var employee in payrollManager.Employees())
        {
            Console.WriteLine($"| {employee.EmployeeId,-15} | {employee.Name,-25} | {employee.Department,-10} | {PayrollManager.CalculateNetSalary(employee),-10} |");
        }
    }


    private static void Main(string[] args)
    {
        Program program = new Program();    
        bool isEnd = false;
        int choice = 0;
        while (!isEnd)
        {
            Console.WriteLine("\n --------- Enter Choice: ---------");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Calculate and Display Net Salary");
            Console.WriteLine("4. Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    program.AddEmployee();
                    break;
                case 2:
                    program.ViewEmployees();
                    break;
                case 3:
                    program.DiplayNetSalary();
                    break;
                case 4:
                    isEnd = true;
                    break;
                default:
                    Console.WriteLine("\nEnter Valid Choice");
                    break;
            }
        }
    }
}
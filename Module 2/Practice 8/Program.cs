using Classes;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Employee employee1 = new Employee("1", "Hirtik", 35000, "Software Engineering");
            //Employee employee1 = new Employee("1", "Hirtik", -35000, "Software Engineering");
            employee1.Name = "Hirtik Malvi";
            //employee1.Department = "HR"; // Error
            Console.WriteLine($"Employee {employee1.ID}: Name: {employee1.Name}, Salary: {employee1.Salary}, AnnualSalary: {employee1.AnnualSalary}, Department: {employee1.Department}");
        }
        catch (ArgumentException e) { 
            Console.WriteLine(e.Message);
        }
    }
}
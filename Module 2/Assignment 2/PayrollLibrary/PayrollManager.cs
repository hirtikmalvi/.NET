using System;

namespace PayrollLibrary
{
    public class PayrollManager
    {
        //private List<Employee> employees;
        private List<Employee> employees = new List<Employee>();

        public static double CalculateNetSalary(Employee employee)
        {
            return employee.BasicSalary + employee.HRA + employee.DA + employee.Bonus;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public List<Employee> Employees()
        {
            List<Employee> list = new List<Employee>();    
            list = employees;
            return list;
        }

        public void DisplayEmployees()
        {
            Console.WriteLine("------ Employee Details ------");

            Console.WriteLine($"| {"ID", -15} | {"Name",-25} | {"Department",-10} | {"BasicSalary",-10} | {"HRA",-10} | {"DA",-10} | {"Bonus",-10}");
            foreach (var employee in employees)
            {
                Console.WriteLine($"| {employee.EmployeeId,-15} | {employee.Name,-25} | {employee.Department,-10} | {employee.BasicSalary,-11} | {employee.HRA,-10} | {employee.DA,-10} | {employee.Bonus,-10}");
            }
        }
    }
}

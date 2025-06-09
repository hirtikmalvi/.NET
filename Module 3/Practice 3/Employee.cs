using System;

namespace Practice_3
{
    abstract class Employee
    {
        abstract public double CalculateSalary(double salary);
    }
    class FullTimeEmployee: Employee
    {
        public override double CalculateSalary(double salary)
        {
            return salary + (salary * 0.1);
        }
    }
    class PartTimeEmployee: Employee
    {
        public override double CalculateSalary(double salary)
        {
            return salary + (salary * 0.05);
        }
    }


}

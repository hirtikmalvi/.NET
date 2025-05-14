using System;

namespace Classes
{
    internal class Employee
    {
        public string ID { get; set; }
        public string Name {  get; set; }

        private decimal _Salary;
        public decimal Salary { 
            get {return _Salary;}
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }
                _Salary = value;
            } }

        public decimal AnnualSalary { 
            get 
            {
                return Salary * 12;
            }
        }

        // Read-Only Department
        public string Department { get; }

        public Employee(string id, string name, decimal salary, string department = "General") {
            ID = id;
            Name = name;
            Salary = salary;
            Department = department;
        }

    }
}

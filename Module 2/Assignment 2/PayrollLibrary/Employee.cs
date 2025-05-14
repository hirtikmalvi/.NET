namespace PayrollLibrary
{
    public class Employee
    {
        private static int _EmployeeId;
        public int EmployeeId { get; }
        public string Name { get; set; }
        public string Department {  get; set; }
        private double _BasicSalary;
        public double BasicSalary
        {
            get { return _BasicSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Basic Salary cannot be negative.");
                }
                _BasicSalary = value;
            }
        }
        public double HRA
        {
            get
            {
                return BasicSalary * 20 * 0.01;
            }
        }

        public double DA
        {
            get { return BasicSalary * 10 * 0.01; }
        }

        public double Bonus
        {
            get
            {
                return BasicSalary * 5 * 0.01;
            }
        }

        public Employee() {}

        public Employee(string name, string department, double basicSalary) {
            _EmployeeId++;
            EmployeeId = _EmployeeId;
            Name = name;
            Department = department;
            BasicSalary = basicSalary;
        }
    }
}

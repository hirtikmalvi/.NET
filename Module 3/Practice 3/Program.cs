using Practice_3;

internal class Program
{
    private static void Main(string[] args)
    {
        // Compile Time Polymorphism (Overloading)
     MathOperations mathOperations = new MathOperations();
        Console.WriteLine($"Two Integer Add: {mathOperations.Add(10,20)}");
        Console.WriteLine($"Three Integer Add: {mathOperations.Add(10,20, 30)}");
        Console.WriteLine($"Double Add: {mathOperations.Add(10.25, 20.15)}");

        // Run Time Polymorphism (Virtual Methods)
        Circle circle = new Circle();
        circle.Radius = 10;
        Console.WriteLine($"Circle Area: {circle.CalculateArea()}");

        Rectangle rectangle = new Rectangle();
        rectangle.Length = 10;
        rectangle.Breadth = 20;
        Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}");

        // Abstract Class
        FullTimeEmployee fEmployee = new FullTimeEmployee();
        Console.WriteLine($"Full Time: {fEmployee.CalculateSalary(50000)}");
        PartTimeEmployee pEmployee = new PartTimeEmployee();
        Console.WriteLine($"Full Time: {pEmployee.CalculateSalary(50000)}");

        // Real World Scenario
        List<Payment> payments = new List<Payment>();
        
        CreditCardPayment creditCardPayment = new CreditCardPayment();
        payments.Add( creditCardPayment );

        UPIPayment upiPayment = new UPIPayment();
        payments.Add ( upiPayment );

        foreach (var payment in payments)
        {
            payment.ProcessPayment();
        }

    }
}
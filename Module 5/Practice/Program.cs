internal class Program
{

    // 1. 1.	Implement a program using Func<T, TResult> to calculate the area of different shapes (circle, rectangle, triangle) based on user input.
    public void AreaCalc()
    {
        //  Func Delegate
        Func<double, double, double> CalculateArea = null;
        bool isEnd = false;
        while (!isEnd) {
            Console.WriteLine("Enter Choice: \n1. Circle\n2. Rectangle\n3. Triangle\n4. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Radius: ");
                    double r = double.Parse(Console.ReadLine());
                    CalculateArea = (x, _) => Math.PI * x * x;
                    Console.WriteLine($"The Result is: {CalculateArea(r, 0)}");

                    break;
                case 2:
                    Console.WriteLine("Enter Length: ");
                    double l = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Breadth: ");
                    double b = double.Parse(Console.ReadLine());
                    CalculateArea = (x, y) => x * y;
                    Console.WriteLine($"The Result is: {CalculateArea(l, b)}");

                    break;
                case 3:
                    Console.WriteLine("Enter Base: ");
                    double tBase = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Height: ");
                    double tH = double.Parse(Console.ReadLine());
                    CalculateArea = (x, y) => 0.5 * x * y;
                    Console.WriteLine($"The Result is: {CalculateArea(tBase, tH)}");
                    break;
                case 4:
                    isEnd = true;
                    return;
            }
        }
    }

    // 2.	Create a dictionary of operations (add, subtract, multiply, divide) implemented as Func<int, int, int> delegates. Allow the user to choose an operation and provide input.

    public void Calculator()
    {
        Dictionary<string, Func<double, double, double>> calc = new Dictionary<string, Func<double, double, double>>()
        {
            { "add", (x, y) => x + y },
            { "subtract", (x, y) => x - y },
            { "multiply", (x, y) => x * y },
            { "divide", (x, y) => x / y },
        };

        Console.WriteLine($"Addition: {(calc.ContainsKey("add") ? calc["add"](10,20) : "Invalid Operation.")}");

        Console.WriteLine($"Subtraction: {(calc.ContainsKey("subtract") ? calc["subtract"](10, 20) : "Invalid Operation.")}");


        Console.WriteLine($"Multiply: {(calc.ContainsKey("multiply") ? calc["multiply"](10, 20) : "Invalid Operation.")}");

        Console.WriteLine($"Division: {(calc.ContainsKey("divide") ? calc["divide"](10, 20) : "Invalid Operation.")}");
    }

    // 3.	Use Func<int, bool> to filter a list of numbers for prime numbers and display the result.

     static Func<int, bool> isPrime = (x) =>
    {
        if (x == 1)
        {
            return false;
        }
        for (int i = 2; i < x; i++)
        {
            if (x % i == 0)
                return false;
        }
        return true;
    };

    //4.	Write a program using Func<string, string> to transform a list of strings (e.g., convert to uppercase, trim whitespace, append a suffix).

    static Func<string, string> TransformString = (input) =>
    {
        return input.Trim().ToUpper();
    };

    // 5.	Implement a method that takes a Func<int, int, bool> to compare two integers and return true if the condition (e.g., greater than, equal) is satisfied.

    static Func<int, int, bool> isGreater = (x, y) => x >= y;

    private static void Main(string[] args)
    {
        Program program = new Program();
        //program.AreaCalc(); // 1.
        //program.Calculator(); // 2.

        // 3.
        //Console.WriteLine($"5 is {(isPrime(5) ? "Prime" : "Not Prime")}");
        //Console.WriteLine($"6 is {(isPrime(6) ? "Prime" : "Not Prime")}");
        //Console.WriteLine($"1 is {(isPrime(1) ? "Prime" : "Not Prime")}");

        // 4.
        //Console.WriteLine($"Transformed String: {TransformString("Hirtik")}");

        // 5.
        Console.WriteLine($"5 > 6 {isGreater(5, 6)}");
        Console.WriteLine($"6 > 5 {isGreater(6, 5)}");
    }
}
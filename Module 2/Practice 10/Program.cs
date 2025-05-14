using Practice_10;

internal class Program
{
    class NonStaticClass
    {
        // Static Counter
        public static int counter = 0;

        public NonStaticClass()
        {
            counter++;
        }

        // Static Method
        public static string StaticMethod(string firstname, string lastname)
        {
            return $"{firstname.Trim()} {lastname.Trim()}";
        }

        // Non-Static Method
        // Calling above static method in non-static method
        public void DisplayFullName(string firstName, string lastName)
        {
            Console.WriteLine(StaticMethod("Hirtik", "Malvi"));
        }
    }
    private static void Main(string[] args)
    {
        // Using MathUtilities.class
        Console.WriteLine($"Sum Of {4} + {5} = {MathUtilities.Add(4, 5)}");

        // Testing Counter
        NonStaticClass nsc1 = new NonStaticClass();
        NonStaticClass nsc2 = new NonStaticClass();

        Console.WriteLine($"Counter = {NonStaticClass.counter}");

        // Using Helper.class
        Helper.Greet("Hirtik");

        // Calling static method in a Non-Static Method
        nsc1.DisplayFullName("Hirtik", "Malvi");
    }
}
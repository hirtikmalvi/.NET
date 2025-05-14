using Practice_6;
internal class Program
{
    private static void Main(string[] args)
    {
        Person person = new Person();
        person.Name = "Hirtik";
        person.Age = 21;
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

// -----------------------------------------------------------------
        Car car = new Car("BMW", "X7", 30000000);
        car.CarDetails();

    }
}
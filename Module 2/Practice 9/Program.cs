using Practice_9;

internal class Program
{
    private static void Main(string[] args)
    {
        Student student = new Student(1,"Hirtik", 21);

        Console.WriteLine($"Student Details: Name: {student.Name}, Age: {student.Age}");
    }
}
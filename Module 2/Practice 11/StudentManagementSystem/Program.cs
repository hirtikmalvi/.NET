using BusinessLogic;

internal class Program
{
    private static void Main(string[] args)
    {
        StudentManager sm = new StudentManager();
        sm.AddStudent("Hirtik", 21);
        sm.AddStudent("Hitesh", 22);
        sm.AddStudent("Jayesh", 23);

        // Getting Dynamic Data
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        sm.AddStudent(name, age);

        // Printing Data
        Console.WriteLine("----------------- Student Details -----------------");
        foreach (var student in sm.GetStudentDetails())
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }

        // Display Average Age
        Console.WriteLine($"Average Age: {sm.CalculateAverageAge()}");
    }
}
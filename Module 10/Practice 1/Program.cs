using Practice_1.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
		try
		{
            using (var context = new SchoolDbContext())
            {
                context.Students.Add(new Student { StudentName = "Vicky" });
                context.Students.Update(new Student { StudentId = 3, StudentName = "Paresh" });
                context.SaveChanges();
                //context.Students.Find(s => s.StudentName == "Hirtik");
                var students = context.Students.Select(s => s).ToList();
                Console.WriteLine(students.Aggregate("Student Details: ", (str, s) => str += $"\n\tId: {s.StudentId}, Name: {s.StudentName}"));
            }
        }
		catch (Exception e)
		{

            Console.WriteLine($"Exception: {e.Message} {e.InnerException}");
		}
    }
}
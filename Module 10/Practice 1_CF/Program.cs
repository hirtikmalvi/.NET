using Practice_1_CF;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Helllo World");
        using (var context = new SchoolContext())
        {
            context.Database.EnsureCreated();

            var grade2 = new Grade()
            {
                GradeName = "2nd Grade",
            };
            var student1 = new Student()
            {
                FirstName = "Jay",
                LastName = "Patel",
                Grade = grade2,
            };
            context.Students.Add(student1);

            context.SaveChanges();

            foreach (var s in context.Students)
            {
                Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");
            }
        }
    }
}
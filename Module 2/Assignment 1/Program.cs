using Assignment_1;

internal class Program
{
    public void PrintPersonDetails(Person[] persons)
    {
        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine("| {0,-15} | {1,-15} | {2,-25} | {3,-12} | {4,-6} | {5,-10} | {6,-12} | {7,-8} | {8,-15} |", "First Name", "Last Name", "Email", "Date of Birth", "Adult", "Sun Sign", "Chinese Sign","Birthday", "Screen Name");

        foreach (var person in persons)
        {
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-25} | {3,-12:dd-MM-yyyy} | {4,-6} | {5,-10} | {6,-12} | {7,-8} | {8,-15} |",
                person.FirstName,
                person.LastName,
                person.Email,
                person.DateOfBirth,
                person.Adult? "Yes" : "No",
                person.SunSign,
                person.ChineseSign,
                person.Birthday ? "Yes" : "No",
                person.ScreenName);
        }
        Console.WriteLine("---------------------------------------------------------------------------------------");
    }
    private static void Main(string[] args)
    {
        Program program = new Program();
        Person[] persons = new Person[2];

        for (int i = 0; i < persons.Length; i++)
        {
            Console.Write("Enter Firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("\nEnter Lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("\nEnter Email: ");
            string email = Console.ReadLine();

            Console.Write("\nEnter Date Of Birth (dd-MM-yyyy): ");
            DateTime dateOfBirth;
            string inputDOB = Console.ReadLine();

            while (!DateTime.TryParseExact(inputDOB, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfBirth))
            {
                Console.Write("\nInvalid Format! Enter Date Of Birth (dd-MM-yyyy): ");
                inputDOB = Console.ReadLine();
            }

            Person person = new Person(firstName, lastName, email, dateOfBirth);

            persons[i] = person;
        }
        program.PrintPersonDetails(persons);
    }
}
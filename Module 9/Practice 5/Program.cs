internal class Program
{
    public static void Practice_1(string path)
    {
        FileStream fileStream = File.Create(path);
        fileStream.Close();

        if (File.Exists(path))
        {
            string[] data = { "Hirtik", "Computer Engineering", "1234567890" };

            File.WriteAllLines(path, data);

            Console.WriteLine("Content Written Successfully.");
        }
        else
        {
            Console.WriteLine("File Not exist");
        }
    }

    public static void Practice_2(string path)
    {
        if (File.Exists(path))
        {
            string[] data = File.ReadAllLines(path);

            Console.WriteLine(data.Aggregate("Reading Data: ", (str, s) => str += $"\n\t{s}"));
        }
        else
        {
            Console.WriteLine("File Not exist");
        }
    }

    public static void Practice_4(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine("File Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("File Not exist");
        }
    }

    public static void Practice_5(string source, string dest)
    {
        if (File.Exists(dest))
        {
            Console.WriteLine("Before: Destination exist");
        }
        else
        {
            Console.WriteLine("Before: Destination does not exist");
        }

        // Following Will give error if destination file exist.
        File.Copy(source, dest);

        // Following Will not give error even if destination file exist.
        //File.Copy(source, dest, true);

        if (File.Exists(dest))
        {
            Console.WriteLine("After: Destination exist");
        }
        else
        {
            Console.WriteLine("After: Destination does not exist");
        }
    }
    private static void Main(string[] args)
    {
        string path1 = @"E:\.NET\Module 9\Practice 5\files\output.txt";

        string path2 = @"E:\.NET\Module 9\Practice 5\files\sample.txt";

        // Practice 3 already done for checking whether the file exists or not.

        string path4 = @"E:\.NET\Module 9\Practice 5\files\deleteMe.txt";

        // Paths for practice 5
        string sourcePath = @"E:\.NET\Module 9\Practice 5\files\source.txt";
        string destPath = @"E:\.NET\Module 9\Practice 5\files\destination.txt";

        //Practice_1(path1);
        //Practice_2(path2);
        //Practice_4(path4);
        Practice_5(sourcePath, destPath);
    }
}
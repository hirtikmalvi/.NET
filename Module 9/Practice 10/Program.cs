internal class Program
{
    public static void Practice_1(string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(path))
        {
            streamWriter.WriteLine("Welcome to C#");
        }
    }

    public static void Practice_2(string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
            streamWriter.WriteLine("Appended Text");
        }
    }

    public static void Practice_3(string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
            streamWriter.WriteLine("Line 1");
            streamWriter.WriteLine("Line 2");
        }
    }

    public static void Practice_4(string path, List<string> users)
    {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
            foreach (var u in users)
            {
                streamWriter.WriteLine($"User: \n\t{u}");
            }
        }
    }

    public static void Practice_5(string path)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(path);

            streamWriter.WriteLine("Adding Data before string getting Flushed.");

            streamWriter.Flush();

            streamWriter.Close();

            streamWriter.WriteLine("Adding Data after string getting Flushed.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
    }

    private static void Main(string[] args)
    {
        string path1 = @"E:\.NET\Module 9\Practice 10\files\greeting.txt";

        string path2 = @"E:\.NET\Module 9\Practice 10\files\file.txt";

        string path3 = @"E:\.NET\Module 9\Practice 10\files\lines.txt";

        string path4 = @"E:\.NET\Module 9\Practice 10\files\formatted.txt";

        string path5 = @"E:\.NET\Module 9\Practice 10\files\flush.txt";

        //Practice_1(path1);
        //Practice_2(path2);
        //Practice_3(path3);
        //Practice_4(path4, new List<string>()
        //{
        //    "Name: John, Age: 30",
        //    "Name: Hirtik, Age: 21",
        //    "Name: Hitesh, Age: 22"
        //});
        Practice_5(path5);
    }
}
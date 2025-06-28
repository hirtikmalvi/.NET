internal class Program
{
    public static void Practice_1_2_3(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)
        {
            Console.WriteLine("File Exists.");
            Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");

            Console.WriteLine($"Size: {fileInfo.Length} bytes");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }

    public static void Practice_4(string path, string newPath)
    {
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)
        {
            Console.WriteLine("File Exists.");
            fileInfo.MoveTo(newPath);
            Console.WriteLine("Name Changed");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }

    public static void Practice_5(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        using (StreamWriter writer = fileInfo.CreateText())
        {
            Console.WriteLine("File Created");
            writer.WriteLine("Name: Hirtik Malvi");
            writer.WriteLine("Department: Computer Engineering");
        }
        fileInfo.Delete();
        Console.WriteLine("File Deleted...");
    }
    private static void Main(string[] args)
    {
        string path1 = @"E:\.NET\Module 9\Practice 11\files\data.txt";

        string path4 = @"E:\.NET\Module 9\Practice 11\files\oldname.txt";

        string newPath4 = @"E:\.NET\Module 9\Practice 11\files\newname.txt";

        string path5 = @"E:\.NET\Module 9\Practice 11\files\unwanted.txt";

        //Practice_1_2_3(path1);
        //Practice_4(path4, newPath2);
        Practice_5(path5);
    }
}
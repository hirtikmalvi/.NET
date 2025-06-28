internal class Program
{
    public static void Practice_1(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        var files = directoryInfo.GetFiles();
        //var files = directoryInfo.EnumerateFiles();

        foreach (var file in files)
        {
            Console.WriteLine($"FileName: {file.Name}");
        }
    }

    public static void Practice_2(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        directoryInfo.Create();
        Console.WriteLine($"Directory Created At: {directoryInfo.CreationTime}");

    }

    public static void Practice_4(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        Console.WriteLine($"Directory Exists?: {directoryInfo.Exists}");
    }

    public static void Practice_5(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        directoryInfo.Delete();

        Console.WriteLine($"Directory Deleted.");
    }

    public static void PracticeForSubDirectories(string path)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        for (int i = 1; i <= 5; i++)
        {
            directoryInfo.CreateSubdirectory($"subdir{i}");
        }

        foreach (var d in directoryInfo.GetDirectories())
        {
            Console.WriteLine($"Name: {d.Name} - Parent: {d.Parent} - FullName: {d.FullName} - Extention: {d.Extension} - Date: {d.CreationTime}");
        }
    }
    private static void Main(string[] args)
    {
        string path1 = @"E:\.NET\Module 9\Practice 12\files";

        string path2 = @"E:\.NET\Module 9\Practice 12\newfolder";

        string path4 = @"E:\.NET\Module 9\Practice 12\test";

        string path5 = @"E:\.NET\Module 9\Practice 12\tempDir";

        string path = @"E:\.NET\Module 9\Practice 12\SubDirectories";

        //Practice_1(path1);
        //Practice_2(path2);
        //Practice_4(path4);
        //Practice_5(path5);
        PracticeForSubDirectories(path);
    }
}
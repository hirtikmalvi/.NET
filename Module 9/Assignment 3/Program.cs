internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"E:\.NET\Module 9\Assignment 3\Gallary";
        var files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file);

            DateTime lastModified = fileInfo.LastWriteTime;
            DateTime now = DateTime.Now;

            if (lastModified.Month != now.Month || lastModified.Year != now.Year)
            {
                fileInfo.Delete();
                Console.WriteLine($"File Deleted: {fileInfo.Name}");
            }
        }
    }
}
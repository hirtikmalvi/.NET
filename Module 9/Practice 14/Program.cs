internal class Program
{
    public static void Practice_1_2(string path)
    {
        Console.WriteLine($"Path: {path}");
        Console.WriteLine($"File Name: {Path.GetFileName(path)} (With Extention)");
        Console.WriteLine($"File Name: {Path.GetFileNameWithoutExtension(path)} (Without Extention)");
    }
    private static void Main(string[] args)
    {
        string path1 = @"C:\files\example.txt";
        //Practice_1_2(path1);

        Console.WriteLine($"Combined Path: {Path.Combine(@"C:\files", "data.txt")}");

        Console.WriteLine($"Extention: {Path.GetExtension(@"C:\\files\\document.pdf")}");

        Console.WriteLine($"Is Path Rooted: {Path.IsPathRooted(@"C:\\files\\example.txt")}");
    }
}
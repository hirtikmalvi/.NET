using System.Security.Authentication;

internal class Program
{
    public static void DisplayFolderStructure(string path, int level)
    {
        string indent = new string(' ', level * 4);
        int count = 1;

        var directories = Directory.GetDirectories(path);
        foreach ( var d in directories )
        {
            Console.WriteLine($"{indent}{count}. {Path.GetFileName(d)}");

            DisplayFolderStructure(d, level + 1);    
            count++;
        }

        var files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            Console.WriteLine($"{indent}{count}. {Path.GetFileName(file)}");
            count++;
        }
    }
    private static void Main(string[] args)
    {
        string path = @"E:\.NET\Module 9\Assignment 2\folders";
        if (Directory.Exists(path))
        {
            Console.WriteLine("\nFolder Structure:\n");
            DisplayFolderStructure(path, 0);
        }
        else
        {
            Console.WriteLine("Invalid path.");
        }
    }
}
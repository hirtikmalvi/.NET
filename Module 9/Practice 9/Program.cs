using System.Globalization;

internal class Program
{
    public static void Practice_1(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            Console.WriteLine($"Content of input.txt: {streamReader.ReadToEnd()}");
        }
    }

    public static void Practice_2(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            Console.WriteLine($"Reading Single Line Content of data.txt: {streamReader.ReadLine()}");
        }
    }

    public static void Practice_3(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            Console.WriteLine($"Reading all Lines of lines.txt: {streamReader.ReadToEnd()}");
        }
    }

    public static void Practice_4(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            string data = streamReader.ReadLine();

            while (data != null)
            {
                Console.WriteLine($"Line: {data}");
                data = streamReader.ReadLine();
            }
        }
    }

    public static void Practice_5(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            int count = 0;

            string data = streamReader.ReadToEnd();

            while (data != null)
            {
                count += data.Split(new char[] { ' ', '\t', '\n' }).Length;

                data = streamReader.ReadLine();
            }

            Console.WriteLine($"Number of Words (Word Count) in textfile.txt: {count}");
        }
    }

    private static void Main(string[] args)
    {
        string path1 = @"E:\.NET\Module 9\Practice 9\files\input.txt";

        string path2 = @"E:\.NET\Module 9\Practice 9\files\data.txt";

        string path3 = @"E:\.NET\Module 9\Practice 9\files\lines.txt";

        string path4 = @"E:\.NET\Module 9\Practice 9\files\file.txt";

        string path5 = @"E:\.NET\Module 9\Practice 9\files\textfile.txt";

        //Practice_1(path1);
        //Practice_2(path2);
        //Practice_3(path3);
        //Practice_4(path4);
        Practice_5(path5);
    }
}
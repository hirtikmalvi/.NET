using System.Text;

internal class Program
{
    public static void CreateAndWriteFile1(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Append);

        byte[] byteData = Encoding.Default.GetBytes("Hello World!");

        fileStream.Write(byteData, 0, byteData.Length);

        fileStream.Close();

        Console.WriteLine($"File Created at {path} and Stored data successfully.");
    }

    public static void ReadFile2(string path)
    {
        string data;
        try
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Practice 6 last problem (5) included here.

            Console.WriteLine($"File Size: {fileStream.Length}");


            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }
            Console.WriteLine($"Retrived Data: {data}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
    }

    public static void CreateAndAppendFile3(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Append);

        byte[] byteData = Encoding.Default.GetBytes("Adding Some Content in input.txt and it will used for read operation.");

        fileStream.Write(byteData, 0, byteData.Length);

        fileStream.Close();

        Console.WriteLine($"File Created at {path} and Stored data successfully.");
    }

    public static void ReadFile3(string path)
    {
        string data;
        try
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Reaet d);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                data = streamReader.ReadToEnd();
            }
            Console.WriteLine($"Retrived Data: {data}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
    }


    public static void ReadAndWriteBinaryData4(string path)
    {
        byte[] byteData = { 0x01, 0xFF, 0x23, 0x7A, 0x10 };

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            fileStream.Write(byteData, 0, byteData.Length);
        }
        Console.WriteLine("Binary data written successfully.");

        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            StreamReader streamReader = new StreamReader (fileStream);

            var data = streamReader.ReadToEnd().Trim();

            foreach (var b in data)
            {
                Console.WriteLine($"Binary Data: {((byte)b)}");
            }

        }
    }

    private static void Main(string[] args)
    {
        string path = @"E:\.NET\Module 9\Practice 6\files\";
        CreateAndWriteFile1($"{path}output.txt");
        ReadFile2($"{path}output.txt");

        CreateAndAppendFile3($"{path}input.txt");
        ReadFile3($"{path}input.txt");

        ReadAndWriteBinaryData4($"{path}binaryData.dat");
    }
}
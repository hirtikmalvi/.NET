// Practice 8 StreamReader is somewhat been practiced here.

internal class Program
{
    public static void Practice_1(string path)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
        {
            writer.Write(12345);
        }
        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            int data = reader.ReadInt32();

            Console.WriteLine($"Read Integer: {data}");
        }
    }
    public static void Practice_2(string path)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
        {
            writer.Write("Hirtik Malvi");
        }
        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            string data = reader.ReadString();

            Console.WriteLine($"Read String: {data}");
        }
    }

    public static void Practice_3(string path)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
        {
            writer.Write(123);
            writer.Write(99.99);
            writer.Write("Hirtik Malvi");
        }
        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            int number = reader.ReadInt32();
            double price = reader.ReadDouble();
            string name = reader.ReadString();

            Console.WriteLine($"Reading Mixed Types: Int: {number}, Double: {price}, String: {name}");
        }
    }

    public static void Practice_4(string path)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
        {
            writer.Write(10);
            writer.Write(20);
            writer.Write(30);
        }
        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var data = reader.ReadInt32();
                Console.WriteLine($"Data: {data}");
            }
        }
    }

    private static void Main(string[] args)
    {
        string path1 = @"E:\.NET\Module 9\Practice 7\files\data.dat";

        string path2 = @"E:\.NET\Module 9\Practice 7\files\sample.dat";

        string path3 = @"E:\.NET\Module 9\Practice 7\files\mixedTypeData.dat";

        string path4 = @"E:\.NET\Module 9\Practice 7\files\data.dat";

        //Practice_1(path1);
        //Practice_2(path2);
        //Practice_3(path3);
        //Practice_4(path4);
        // Practice 5 is already practiced in between the above practices.
    }
}
using System.Threading.Tasks;

internal class Program
{
    static async Task<int> LongProcess()
    {
        Console.WriteLine("LongProcess Started");

        await Task.Delay(4000); // hold execution for 4 seconds

        Console.WriteLine("LongProcess Completed");
        return 10;
    }

    static void ShortProcess()
    {
        Console.WriteLine("ShortProcess Started");

        //do something here

        Console.WriteLine("ShortProcess Completed");
    }

    static async Task<int> LongProcess1()
    {
        Console.WriteLine("Long Process 1 started");
        await Task.Delay(2500);
        Console.WriteLine("Long Process 1 Completed");
        return 10;
    }
    static async Task<int> LongProcess2()
    {
        Console.WriteLine("Long Process 2 started");
        await Task.Delay(2500);
        Console.WriteLine("Long Process 2 Completed");
        return 20;
    }
    static async Task Main(string[] args)
    {
        // Example 1
        //var result = LongProcess();
        //ShortProcess();
        //var value = await result;
        //Console.WriteLine($"{value}");

        // Example 2
        var longProcess1 = LongProcess1();
        var longProcess2 = LongProcess2();

        Console.WriteLine("After Processes has started....");

        var result1 = await longProcess1;
        Console.WriteLine($"Result 1: {result1}");

        var result2 = await longProcess2;
        Console.WriteLine($"Result 2: {result2}");

        Console.ReadKey();
    }
}
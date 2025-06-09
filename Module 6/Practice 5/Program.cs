using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        ArrayList data = new ArrayList();
        data.Add(1);
        data.Add("Hirtik");
        data.Add("Hitesh");
        data.Add(2);
        data.Add(2.5f);
        data.Add(4.556f);
        data.Add(8.9);
        // 1.	Use OfType<T> to filter only integer elements from a mixed collection.
        Console.WriteLine($"Only Integers: {string.Join(", ", data.OfType<int>())}");

        // 3.	Use OfType to filter all floating-point numbers from a collection and calculate their average.
        Console.WriteLine($"Only Floating Point Numbers: {string.Join(", ", data.OfType<float>())}, Average: {data.OfType<float>().Average()}");

    }
}
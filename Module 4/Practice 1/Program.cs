using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, decimal> map = new Dictionary<string, decimal>();
        map.Add("Maggie", 12);
        map.Add("Keyboard", 1250);
        map.Add("Mouse", 300);
        map.Add("TV", 33500);
        Console.WriteLine(map.ContainsKey("Maggieee") ? map["Maggie"] : "Not Found");
    }
}
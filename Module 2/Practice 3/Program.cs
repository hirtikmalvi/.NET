class TestClass
{
    public const int x = 434;
    public readonly string Name;
    public TestClass()
    {
        Name += " Malvi";
        Console.WriteLine($"Constructor: {Name}");
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        TestClass testClass = new TestClass();
        Console.WriteLine($"Main: {testClass.Name}");
    }
}
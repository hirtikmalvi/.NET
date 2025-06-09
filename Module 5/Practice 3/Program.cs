class Calculator
{
    public float Add(float a, float b)
    {
        return a + b;
    }
    public float Subtract(float a, float b)
    {
        return a - b;
    }
    public void Multiply(float a, float b)
    {
        Console.WriteLine($"Multiplication: {a * b}");
    }
    public void Division(float a, float b)
    {
        if (b != 0)
        {
            Console.WriteLine($"Division: {a / b}");
        }
        else
        {
            Console.WriteLine("Since b is zero, division can not be performed.");
        }
    }
}

class StringProcesser
{
    public delegate string TransformOperation(string input);

    public static string Capitalise(string input)
    {
        return char.ToUpper(input[0]) + input.Substring(1);
    }
    public static string Reverse(string input)
    {
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
    public static string ApplyTransformation(string input, TransformOperation operation)
    {
        return $"Result: {operation(input)}";
    }
}

internal class Program
{
    // 1.
    List<int> list = new List<int>() { 1,2,3,6,5,4,9,8,7,0};

    public delegate void SortListDelegate(string order);

    public void SortList(string order)
    {
        if (order == "a")
        {
            list.Sort();
        }
        else if(order == "d") 
        {
            list.Sort((a,b) => b.CompareTo(a));
        }
    }

    // 2. Delegates for 2 (Calculator)
    public delegate float DelAdd(float a, float b);
    public delegate float DelSub(float a, float b);
    public delegate void DelMul(float a, float b);
    public delegate void DelDiv(float a, float b);

    private static void Main(string[] args)
    {
        Program program = new Program();

        // 1.
        //SortListDelegate sortListDelegate = new SortListDelegate(program.SortList);

        //sortListDelegate("a");
        //Console.WriteLine($"After A: {string.Join(", ", program.list)}");


        //sortListDelegate("d");
        //Console.WriteLine($"After D: {string.Join(", ", program.list)}");

        // 2.
        //Calculator calculator = new Calculator();
        //DelAdd add = new DelAdd(calculator.Add);
        //DelSub sub = new DelSub(calculator.Subtract);
        //DelMul mul = new DelMul(calculator.Multiply);
        //DelDiv div = new DelDiv(calculator.Division);

        //Console.WriteLine($"Add: {add(10,20)}");
        //Console.WriteLine($"Subtract: {sub(10,20)}");
        //mul(10, 20);
        //div(20,10);

        // 3.
        Console.WriteLine(StringProcesser.ApplyTransformation("hirtik", StringProcesser.Capitalise));
        Console.WriteLine(StringProcesser.ApplyTransformation("hirtik", StringProcesser.Reverse));
        

    }
}
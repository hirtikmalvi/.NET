using Practice_4;

class Product
{
    public decimal Price { get; set; }
    public double DiscountRate 
    { 
        get;
        set;
    }
    public decimal DiscountedPrice 
    { 
        get 
        { 
           decimal discountedPrice = Price - ((decimal)DiscountRate * Price / 100);
            return discountedPrice;
        } 
    }
}
class Order
{
    private string OrderId;
    private List<string> Items = new List<string>();
    private decimal TotalAmount = 0;

    public Order()
    {
        OrderId = DateTime.UtcNow.Ticks.ToString();
    }

    public void AddItem(string itemName, decimal itemPrice)
    {
        Items.Add(itemName);
        TotalAmount += itemPrice;
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"OrderID: {OrderId}");
        foreach (var item in Items)
        {
            Console.WriteLine($"Itemname: {item}");
        }
        Console.WriteLine($"Total Amount: {TotalAmount}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        try
        {
            account.SetBalance = 5000;
            account.Deposit(1000);
            Console.WriteLine($"Deposit 1000: {account.SetBalance}");
            account.Withdraw(3000);
            Console.WriteLine($"Withdraw 5000: {account.SetBalance}");
        }
        catch (Exception ex) { 
            Console.WriteLine($"Exception Caught: {ex.Message}");            
        }
        Product product = new Product();    
        product.Price = 100;
        product.DiscountRate = 10;
        Console.WriteLine($"Discounted Price: {product.DiscountedPrice}");

        Order order = new Order();
        order.AddItem("Maggie", 12);
        order.AddItem("Keyboard", 1150);
        order.AddItem("AC", 35000);
        order.DisplayOrderDetails();

        Student student = new Student();

        try
        {
            student.SetName("Hirtik Malvi");
            student.AddMarks(98);
            student.AddMarks(91);
            student.AddMarks(86);
            student.AddMarks(93);
            student.AddMarks(90);
            student.AddMarks(95);
            Console.WriteLine($"Student Report Card: StudentID {student.GetStudentID()}, Name: {student.GetName()}, Percentage: {student.GetPercentage()}");
        }
        catch (Exception ex) {
            Console.WriteLine($"Exception Caught: {ex.Message}");
        }
    }
}
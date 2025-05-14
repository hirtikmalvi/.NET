using Classes;
internal class Program
{
    private static void Main(string[] args)
    {
        BankAccount account;
        try
        {
            account = new BankAccount("Hirtik", 1000);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating account with negative balance");
            Console.WriteLine(e.ToString());
            return;
        }
        try
        {
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to overdraw");
            Console.WriteLine(e.ToString());
        }
        try
        {
            account.MakeDeposit(5000, DateTime.Now, "Scholarship From Government");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to Deposit Negative Balance");
            Console.WriteLine(e.ToString());
        }
        Console.WriteLine($"{account.GetAccountHistory()}");
    }
}
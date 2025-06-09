using System.Timers;

class StockArgs: EventArgs
{
    public string StockName {  get; set; }
    public float StockPrice {  get; set; }
}
class Stock
{
    public event EventHandler<StockArgs> StockIncreaseEvent;

    public void IncreaseStock(float stockPrice, float threshold)
    {
        if (stockPrice > threshold)
        {
            OnIncreaseStock(new StockArgs
            {
                StockName = "Tata",
                StockPrice = stockPrice,
            });
        }
        Console.WriteLine($"New Stock Price {stockPrice}");
    }

    protected void OnIncreaseStock(StockArgs e)
    {
        StockIncreaseEvent?.Invoke(this, e);
    }
}

class StockService
{
    public void HandleStockIncrease(object sender, StockArgs e)
    {
        Console.WriteLine($"Stock Price has been Increased beyond the threshold.");
    }
}

// 3. Develop a Timer class that raises an event every second. Create a subscriber class that listens to this event and displays the current time.

class Timer
{
    System.Timers.Timer timer;
    public event EventHandler RaiseEventEverySecond;
    // Raise Event
    public void RaiseEvent()
    {
        timer = new System.Timers.Timer(1000);
        timer.Elapsed += OnEachSecond;
    }

    public void OnEachSecond(object sender, ElapsedEventArgs e)
    {
        RaiseEventEverySecond?.Invoke(this, EventArgs.Empty);
    }

    public void Start()
    {
        timer.Start();
    }
    public void Stop()
    {
        timer.Stop();
    }
}
// Subscriber
class DisplayClock
{
    // Event Handler
    public void ShowTime(object sender, EventArgs e)
    {
        Console.WriteLine($"Current Time: {DateTime.Now}");
    }
}

// 4.	Write a program where a BankAccount class raises an InsufficientFunds event when a withdrawal exceeds the balance. Implement multiple subscribers to log the event and alert the user.
class BankAccount
{
    public float Balance {  get; set; }

    public delegate void AccountDelegate(string message);

    public event AccountDelegate BankAccountEvents;

    public void Withdraw(float amount)
    {
        if (Balance - amount < 0)
        {
            BankAccountEvents?.Invoke("Insufficient Balance...");
        }
        else
        {
            Balance -= amount;
        }
    }
}

class BankService
{
    public void HandleEvent(string message)
    {
        Console.WriteLine($"Message: {message}");
    }
}

// 5.	Implement an event system for a Door class where an event DoorOpened is raised when the door state changes. Have different subscribers respond to the event (e.g., log the state, notify security).

class Door
{
    public bool isOpen {  get; set; }

    public event EventHandler DoorOpened;

    public void ChangeState()
    {
        isOpen = !isOpen;
        DoorOpened?.Invoke(this, EventArgs.Empty);
    }
}

class Logger
{
    public void Log(object sender, EventArgs e)
    {
        Console.WriteLine("Log: Door State Has been changed.");
    }
}

class Security
{
    public void SecurityLog(object sender, EventArgs e)
    {
        Console.WriteLine("Security Notifcation: Door State has been changed.");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // 2.
        //Stock stock = new Stock();
        //StockService stockService = new StockService();

        //stock.StockIncreaseEvent += stockService.HandleStockIncrease;
        //stock.IncreaseStock(1000, 5000); // Ok
        //stock.IncreaseStock(5000, 1000);// beyond threshold

        // 3.
        //var timer = new Timer();
        //var displayClock = new DisplayClock();

        //timer.RaiseEventEverySecond += displayClock.ShowTime;

        //timer.RaiseEvent();
        //timer.Start();

        //Console.ReadKey();
        //timer.Stop();

        // 4.
        //BankAccount bankAccount = new BankAccount();
        //BankService bankService = new BankService();
        //bankAccount.BankAccountEvents += bankService.HandleEvent;
        //bankAccount.Balance = 2000;
        //Console.WriteLine($"Before Balance: {bankAccount.Balance}");

        //bankAccount.Withdraw(3000);
        //Console.WriteLine($"After Balance: {bankAccount.Balance}");

        // 5.
        var door = new Door();
        var logger = new Logger();
        var security = new Security();

        door.DoorOpened += logger.Log;
        door.DoorOpened += security.SecurityLog;

        door.isOpen = false;

        Console.WriteLine($"Before Door: {(door.isOpen ? "Open" : "Closed")}");

        door.ChangeState();

        Console.WriteLine($"After Door: {(door.isOpen ? "Open" : "Closed")}");
    }
}
// PRACTICE FOR BUTTON
//class Button
//{
//    public delegate void ButtonClickedEventHandler(string message);

//    public event ButtonClickedEventHandler onClick;

//    public void Click()
//    {
//        Console.WriteLine("Button is clicked.");

//        onClick?.Invoke($"Button was clicked at {DateTime.Now}");
//    }
//}

//class NotificationService
//{
//    public void HandleClick(string message)
//    {
//        Console.WriteLine($"Notification received: {message}");
//    }
//}

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Button button = new Button();
//        NotificationService notifier = new NotificationService();

//        button.onClick += notifier.HandleClick;

//        button.Click();
//    }
//}

// Simplified above code with Built-In EventHandler

//class Button
//{
//    public event EventHandler Clicked;

//    public void Click()
//    {
//        Console.WriteLine("Button is clicked.");

//        Clicked?.Invoke(this, EventArgs.Empty);
//    }
//}

//class Logger
//{
//    public void Log(object sender, EventArgs e)
//    {
//        Console.WriteLine($"Log: Button clicked.");
//    }
//}

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Button button = new Button();
//        Logger logger = new Logger();

//        button.Clicked += logger.Log;

//        button.Click();
//    }
//}


// Real-Life Example: File Download System

// 1. Create a Custom EventArgs Class
using System;

public class DownloadCompleteEventArgs: EventArgs
{
    public string FileName {  get; set; }
    public int FileSizeMB {  get; set; }
    public DateTime CompletedAt { get; set; }
}


// 2. Publisher Class (Downloader)
class Downloader
{
    public event EventHandler<DownloadCompleteEventArgs> DownloadCompleted;

    public void Download(string fileName)
    {
        Console.WriteLine($"Downloading {fileName}...");

        // Simulate download
        Thread.Sleep(1000);


        // Raise event after "download"
        OnDownloadCompleted(new DownloadCompleteEventArgs
        {
            CompletedAt = DateTime.Now,
            FileName = fileName,
            FileSizeMB = new Random().Next(10, 100)
        });
    }

    protected virtual void OnDownloadCompleted(DownloadCompleteEventArgs e)
    {
        DownloadCompleted?.Invoke(this, e);
    }
}

//3.Subscriber(UI Handler)
class NotificationService
{
    public void ShowDownloadInfo(object sender, DownloadCompleteEventArgs e)
    {
        Console.WriteLine($"Download Complete: {e.FileName} ({e.FileSizeMB} MB) at {e.CompletedAt}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var downloader = new Downloader();
        var notifier = new NotificationService();

        // Subscribe to the event
        downloader.DownloadCompleted += notifier.ShowDownloadInfo;

        downloader.Download("GTA V");
    }
}
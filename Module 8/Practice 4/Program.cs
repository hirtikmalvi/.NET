using System.ComponentModel;
using System.Reflection.Metadata;
using System;
using System.Threading.Tasks;

internal class Program
{
    // 1. Asynchronous File Download
    //    Write a method that uses async and await to download a file from a given URL and save it locally.Ensure that the method can handle the download asynchronously and provide feedback on the download progress.
    public static async Task Downloader(string URL)
    {
        Console.WriteLine($"Downloading file from URL: {URL}");
        for (int i = 0; i <= 100; i = i + 20)
        {
            await Task.Delay(500);
            Console.WriteLine($"Download Status: {i}%");
        }
        await Task.Delay(500);
        Console.WriteLine("Download Complete");
    }

    // 2. Asynchronous Database Query
    // Implement an async method to query customer details from a database.The method should simulate a database delay using Task.Delay and return the customer data asynchronously.
    public static async Task<string> GetUserFromDB(int Id)    
    {
        List<string> customers = new List<string>()
        {
            "Hirtik", "Hitesh", "Jayesh", "Jay"
        };

        Console.WriteLine($"Searching Customer...");

        await Task.Delay(2000);

        var foundUser = customers.ElementAtOrDefault(Id);

        return foundUser == null ? "User not Found" : foundUser;
    }

    // 3. Parallel API Calls
    // Write an async method that makes parallel API calls to fetch product details from three different online stores.Use await for each request and ensure that all data is returned in a consolidated format once all calls are completed.

    public static async Task<string> SimulateFetch(string storeName)
    {
        await Task.Delay(2000);
        return $"{storeName} - Product details fetched.";
    }
    public static async Task ProductSimulateFetchAsync()
    {
        Task<string> store1 = SimulateFetch("Store 1");
        Task<string> store2 = SimulateFetch("Store 2");
        Task<string> store3 = SimulateFetch("Store 3");

        var result = await Task.WhenAll(store1, store2, store3);
        Console.WriteLine($"P3 Result: {string.Join(", ", result)}");
    }

    private static async Task Main(string[] args)
    {
        // 1
        //Downloader("www.xyz.com");

        // 2
        //var p2 = GetUserFromDB(1);
        //Console.WriteLine($"P2. User Details: {p2.Result}");

        // 3
        ProductSimulateFetchAsync();
        Console.ReadKey();
    }
}
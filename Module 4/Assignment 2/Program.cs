using Assignment_2.Models;
using Assignment_2.Services;

internal class Program
{

    private static void Main(string[] args)
    {
        Bookservices bookService = new Bookservices();

        while (true)
        {
            Console.WriteLine("\n1. Add Book\n2. Find By Author\n3. Remove Book\n4. View All Books\n5. Get Index Of BookID in separate BookIDs Array\n6. Borrow A Book\n7. Show Recent Borrowed Books\n111. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Book ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Author: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Availability: ");
                    bool availability = bool.Parse(Console.ReadLine());

                    bookService.AddBook(id, title, author, availability);
                    break;
                case 2:
                    Console.WriteLine("Author Name: ");
                    string authorName = Console.ReadLine();
                    var books = bookService.GetBookByAuthor(authorName);
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.BookID} - {book.Title} - {book.Author} - {(book.Availability ? "Available" : "Not Available")}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter BookID: ");
                    int removeBookId = int.Parse(Console.ReadLine());
                    bookService.RemoveBookByID(removeBookId);
                    break;
                case 4:
                    bookService.ShowAllBooks();
                    break;
                case 5:
                    Console.WriteLine("Enter Book Id: ");
                    int bookId = int.Parse(Console.ReadLine());

                    int index = bookService.GetIndexOfBookID(bookId);
                    if(index < 0)
                    {
                        Console.WriteLine("Index could not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Index is {index}");
                    }

                    break;
                case 6:
                    Console.WriteLine("Enter Book Id to Borrow: ");
                    bookId = int.Parse(Console.ReadLine());
                    bookService.BorrowBook(bookId);
                    break;
                case 7:
                    bookService.ShowRecentlyBorrowed();
                    break;
                case 8:

                    break;
                case 9:
                    break;
                case 111:
                    return;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }
}
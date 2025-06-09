using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Models;

namespace Assignment_2.Services
{
    public class Bookservices
    {
        private List<Book> books = new List<Book>();
        private int[] bookIds;
        private Stack<Book> recentlyBorrowed = new Stack<Book>();
        private Dictionary<int, Queue<User>> bookWaitingQueues = new Dictionary<int, Queue<User>>();

        // Task 1: Manage Book Collection (Collections)
        public void AddBook(int id, string title, string author, bool availability)
        {
            Book book = new Book(id, title, author, availability);
            books.Add(book);
            Console.WriteLine("Book Added.");
        }

        public List<Book> GetBookByAuthor(string author)
        {
            return books.FindAll(book => book.Author.Trim().ToLower() == author.Trim().ToLower()).ToList();
        }

        public void RemoveBookByID(int bookId)
        {
            string message = books.RemoveAll(b => b.BookID == bookId) > 0 ? $"Book with BookID {bookId} has been deleted" : "Book could not be deleted or does not exist.";
            Console.WriteLine(message);
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("--------- Books ---------");
            foreach (var book in books) 
            {
                Console.WriteLine($"{book.BookID} - {book.Title} - {book.Author} - {(book.Availability ? "Available" : "Not Available")}");
            }
        }

        // Task 2: Efficient Search in Book List (Array)
        private void StoreBookIds()
        {
            int j = 0;
            bookIds = new int[books.Count];
            for (int i = 0; i < books.Count; i++)
            {
                bookIds[j++] = books[i].BookID;
            }
        }

        private bool IsArraySorted()
        {
            StoreBookIds();
            for (int i = 0; i < bookIds.Length - 1; i++)
            {
                if (bookIds[i] > bookIds[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetIndexOfBookID(int bookId)
        {
            if (!IsArraySorted())
            {
                Array.Sort(bookIds);
            }
            return Array.BinarySearch(bookIds, bookId);
        }

        // Task 3: Book Borrowing (Stack and Queue)
        public void BorrowBook(int bookId)
        {
            Book book = books.Find(b => b.BookID == bookId);
            if (book != null && book.Availability)
            {
                book.Availability = false;
                if (recentlyBorrowed.Count == 5)
                {
                    recentlyBorrowed.Pop();
                }
                recentlyBorrowed.Push(book);
                Console.WriteLine($"Book borrowed: {book.BookID} - {book.Title}.");
            }
            else
            {
                Console.WriteLine($"Book does not exist or Not Available.");
            }
        }

        public void ShowRecentlyBorrowed()
        {
            Console.WriteLine($"\nRecently Borrowed Books: ");
            foreach (var book in recentlyBorrowed)
            {
                Console.WriteLine($"{book.BookID} - {book.Title}");
            }
        }

        // Task 4: Generic Collection for Borrowing Records (Generic Collections)
        public User user1 = new User { Name = "Hirtik", UserId = 1};
        public User user2 = new User { Name = "Hitesh", UserId = 2};

        public void AddToQueue(Book book, User user)
        {
            if (!bookWaitingQueues.ContainsKey(book.BookID))
            {
                bookWaitingQueues.Add(book.BookID, new Queue<User>());
            }
            bookWaitingQueues[book.BookID].Enqueue(user);
            Console.WriteLine($"{user.Name} added to waiting queue for the Book: {book.BookID} - {book.Title}.");
        }

        public void ServeNextUser(Book book)
        {
            if (bookWaitingQueues.ContainsKey(book.BookID) && bookWaitingQueues[book.BookID].Count > 0)
            {
                var user = bookWaitingQueues[book.BookID].Dequeue();
                Console.WriteLine($"User {user.UserId} - {user.Name} can now borrow the book {book.BookID} - {book.Title}.");
            }
            else
            {
                Console.WriteLine("No one in the waiting queue for this book.");
            }
        }
    }
}

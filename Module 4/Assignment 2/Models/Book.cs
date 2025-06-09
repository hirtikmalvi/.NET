using System;

namespace Assignment_2.Models
{
    public class Book
    {
        public int BookID {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Availability {  get; set; }

        public Book(int bookId, string title, string author, bool availability)
        {
            BookID = bookId;
            Title = title;
            Author = author;
            Availability = availability;
        }
    }
}

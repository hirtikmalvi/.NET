﻿namespace LibraryManagement_A2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int YearPublished { get; set; }
        public int Stock { get; set; }

    }
}

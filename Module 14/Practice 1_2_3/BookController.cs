using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_1_2_3
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private List<Book> _books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Book 1",
                Author = "Author 1"
            },
            new Book
            {
                Id = 2,
                Title = "Book 2",
                Author = "Author 2"
            },
            new Book
            {
                Id = 3,
                Title = "Book 3",
                Author = "Author 3"
            }
        };
        
        public List<Book> GetBooks()
        {
            return _books;

        }

        public Book? GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book;
        }
    }
}

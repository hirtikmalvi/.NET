using System.Text.RegularExpressions;
using LibraryManagement_A2.Helper;
using LibraryManagement_A2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement_A2.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery] BookQuery bookQuery)
        {
            if (bookQuery.pageNumber <= 0 || bookQuery.pageSize <= 0)
            {
                bookQuery.pageNumber = 1;
                bookQuery.pageSize = 10;
            }

            //var books = await _context.Books.Skip((bookQuery.pageNumber - 1) * bookQuery.pageSize).Take(bookQuery.pageSize).ToListAsync();

            IQueryable<Book> query = _context.Books.Where(b => b.Stock > 0);

            if (!string.IsNullOrEmpty(bookQuery.sortBy))
            {
                switch (bookQuery.sortBy)
                {
                    case "price":
                        query = bookQuery.order == "desc" ? query.OrderByDescending(q => q.Price) : query.OrderBy(q => q.Price);
                        break;
                    case "title":
                        query = bookQuery.order == "desc" ? query.OrderByDescending(q => q.Title) : query.OrderBy(q => q.Title);
                        break;
                    default:
                        query = query.OrderBy(q => q.Id);
                        break;
                }
            }

            var books = await query.Skip((bookQuery.pageNumber - 1) * bookQuery.pageSize).Take(bookQuery.pageSize).ToListAsync();

            if (books.Count == 0)
            {
                return NotFound(new
                {
                    Message = "No Books Available."
                });
            }
            return Ok(books);
        }

        [HttpGet("GetByTitle")]
        public async Task<IActionResult> GetBookByTitle([FromQuery] string title)
        {
            //var books = await _context.Books.Where(b => b.Title.Trim().ToLower() == title.Trim().ToLower()).ToListAsync();

            var books = await _context.Books.Where(b => b.Title.Trim().ToLower().Contains(title.Trim().ToLower())).ToListAsync();

            if (books.Count == 0)
            {
                return NotFound(new
                {
                    Message = $"No books found with title {title}."
                });
            }
            return Ok(books);
        }

        [HttpGet("author/{authorName}")]
        public async Task<IActionResult> GetBookByAuthorName(string authorName)
        {
            var books = await _context.Books.Where(b => b.Author.Trim().ToLower() == authorName.Trim().ToLower()).ToListAsync();

            if (books.Count == 0)
            {
                return NotFound(new
                {
                    Message = $"No books found with AuthorName {authorName}."
                });
            }
            return Ok(books);
        }

        [HttpGet("year/{year:int}")]
        public async Task<IActionResult> GetBookByYear(int year)
        {
            if (!Regex.IsMatch(year.ToString(), @"^[0-9]{4}$"))
            {
                return NotFound(new
                {
                    Message = $"Enter a valid year."
                });
            }
            var books = await _context.Books.Where(b => b.YearPublished == year).ToListAsync();

            if (books.Count == 0)
            {
                return NotFound(new
                {
                    Message = $"No books found with year {year}."
                });
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book bookToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Books.AddAsync(bookToAdd);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = bookToAdd.Id }, bookToAdd);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new
                {
                    Message = $"No book found with ID {id}."
                });
            }
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book bookToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != bookToUpdate.Id)
            {
                return BadRequest(new
                {
                    Message = "Id mismatch."
                });
            }
            var bookExists = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (bookExists == null)
            {
                return NotFound(new
                {
                    Message = $"Book not found with ID {id}."
                });
            }
            bookExists.Title = bookToUpdate.Title;
            bookExists.Author = bookToUpdate.Author;
            bookExists.YearPublished = bookToUpdate.YearPublished;
            bookExists.Price = bookToUpdate.Price;
            bookExists.Stock = bookToUpdate.Stock;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new
                {
                    Message = $"Book not found with ID {id}."
                });
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = $"Book with ID {id} deleted successfully."
            });
        }
    }
}

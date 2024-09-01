using libri.Data;
using libri.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libri.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        // GET: api/BookApi/GetBooks
        [HttpGet]
        public IActionResult GetBooks()
        {
            using (BooksContext db = new BooksContext())
            {
                var books = db.Books
                    .Include(b => b.Genres) 
                    .Select(b => new
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author,
                        PublishedYear = b.PublishedYear,
                        Genres = b.Genres.Select(g => new
                        {
                            GenreId = g.GenreId,
                            Name = g.Name
                        }).ToList()
                    })
                    .ToList();

                return Ok(books);
            }
        }

        // GET: api/BookApi/GetGenres
        [HttpGet]
        public IActionResult GetGenres()
        {
            return Ok(BookManager.GetGenres());
        }

        // GET: api/BookApi/GetBookById/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            Book book = BookManager.GetBookById(id);
            return Ok(book);
        }

        // POST: api/BookApi/InsertBook
        [HttpPost]
        public IActionResult InsertBook([FromForm] Book book, [FromForm] List<int> SelectedGenreIds)
        {
            BookManager.InsertBook(book, SelectedGenreIds);
            return Ok();
        }

        // PUT: api/BookApi/UpdateBook
        [HttpPut]
        public IActionResult UpdateBook([FromForm] Book book, [FromForm] List<int> SelectedGenreIds)
        {
            BookManager.UpdateBook(book, SelectedGenreIds);
            return Ok();
        }

        // DELETE: api/BookApi/DeleteBook/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            BookManager.DeleteBook(id);
            return Ok();
        }
    }


}

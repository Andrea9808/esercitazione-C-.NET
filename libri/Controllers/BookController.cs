using libri.Data;
using libri.Models;
using Microsoft.AspNetCore.Mvc;

namespace libri.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            List<Book> books = BookManager.GetBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            Book book = BookManager.GetBookById(id);
            return View(book);
        }

        public IActionResult Create()
        {
            //ritorno la vista anche con i generi
            var model = new BookFormModel();
            {
                model.Genres = BookManager.GetGenres();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.Genres = BookManager.GetGenres();
                return View(data);
            }

            // Creazione del nuovo libro con tutte le proprietà
            var book = new Book
            {
                Title = data.Book.Title,
                Author = data.Book.Author,
                PublishedYear = data.Book.PublishedYear,
            };

            // Inserisci il libro e associa i generi
            BookManager.InsertBook(book, data.SelectedGenreIds);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            // Recupera il libro da modificare usando l'ID
            var bookToEdit = BookManager.GetBookById(id);

            if (bookToEdit == null)
            {
                return View("Errore"); 
            }

            // Crea il modello per la vista
            var model = new BookFormModel
            {
                Book = bookToEdit,
                Genres = BookManager.GetGenres(),
                SelectedGenreIds = bookToEdit.Genres.Select(g => g.GenreId).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(BookFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.Genres = BookManager.GetGenres();
                return View(data);
            }

            var book = new Book
            {
                BookId = data.Book.BookId,
                Title = data.Book.Title,
                Author = data.Book.Author,
                PublishedYear = data.Book.PublishedYear,
            };

            BookManager.UpdateBook(book, data.SelectedGenreIds);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Elimina il libro con l'ID specificato
            BookManager.DeleteBook(id);

            // Reindirizzamento alla pagina indice dopo l'eliminazione
            return RedirectToAction("Index");
        }

    }
}

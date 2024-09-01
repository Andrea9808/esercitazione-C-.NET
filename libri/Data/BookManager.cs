using libri.Models;
using Microsoft.EntityFrameworkCore;

namespace libri.Data
{
    public class BookManager
    {
        //libri statici
        public static void AddStaticBook()
        {
            using (BooksContext db = new BooksContext())
            {
                if (db.Books.Count() == 0)
                {
                    //Signore degli anelli
                    Book defaultBook = new Book("Il signore degli anelli", "J.R.R. Tolkien", new DateOnly(1954, 7, 29));
                    db.Books.Add(defaultBook);
                    db.SaveChanges();
                }
                
            }
        }

        //crea generi statici
        public static void AddStaticGenres()
        {
            using (BooksContext db = new BooksContext())
            {
                if (db.Genres.Count() == 0)
                {
                    Genre fantasy = new Genre("Fantasy");
                    Genre adventure = new Genre("Adventure");
                    Genre fiction = new Genre("Fiction");
                    Genre horror = new Genre("Horror");
                    Genre romance = new Genre("Romance");
                    Genre scifi = new Genre("Science Fiction");
                    Genre mystery = new Genre("Mystery");
                    Genre thriller = new Genre("Thriller");

                    db.Genres.AddRange(fantasy, adventure, fiction, horror, romance, scifi, mystery, thriller);
                    db.SaveChanges();
                }
            }
        }

        //lettura generi
        public static List<Genre> GetGenres()
        {
            using (BooksContext db = new BooksContext())
            {
                return db.Genres.ToList();
            }
        }


        //lettura libri
        public static List<Book> GetBooks()
        {
            using (BooksContext db = new BooksContext())
            {
                return db.Books.Include(b => b.Genres).ToList();
            }
        }


        //lettura libro per id
        public static Book GetBookById(int bookId)
        {
            using (BooksContext db = new BooksContext())
            {
                return db.Books.Include(b => b.Genres).FirstOrDefault(b => b.BookId == bookId);
            }
        }


        //crea nuovo libro
        public static void InsertBook(Book book, List<int> SelectedGenreIds = null)
        {
            using BooksContext db = new BooksContext();

            if (SelectedGenreIds != null)
            {
                book.Genres = new List<Genre>();

                foreach (var GenereId in SelectedGenreIds)
                {
                    Genre genre = db.Genres.Find(GenereId);
                    if (genre != null)
                    {
                        book.Genres.Add(genre);
                    }
                }
            }

            db.Books.Add(book);
            db.SaveChanges();
        }

        //modifica libro
        public static void UpdateBook(Book book, List<int> SelectedGenreIds = null)
        {
            using (BooksContext db = new BooksContext())
            {
                Book oldBook = db.Books.Include(b => b.Genres).FirstOrDefault(b => b.BookId == book.BookId);

                if (oldBook != null)
                {
                    oldBook.Title = book.Title;
                    oldBook.Author = book.Author;
                    oldBook.PublishedYear = book.PublishedYear;

                    if (SelectedGenreIds != null)
                    {
                        oldBook.Genres.Clear();

                        foreach (var GenereId in SelectedGenreIds)
                        {
                            Genre genre = db.Genres.Find(GenereId);
                            if (genre != null)
                            {
                                oldBook.Genres.Add(genre);
                            }
                        }
                    }

                    db.SaveChanges();
                }
            }
        }

        //eliminazione libro
        public static void DeleteBook(int bookId)
        {
            using (BooksContext db = new BooksContext())
            {
                Book book = db.Books.Find(bookId);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

    }
}

using libri.Models;

namespace libri.Data
{
    public class BookFormModel
    {
        public Book Book { get; set; } = new Book();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<int> SelectedGenreIds { get; set; } = new List<int>();


        //costruttore
        public BookFormModel()
        {
        }

        public BookFormModel(Book book, List<Genre> genres)
        {
            Book = book;
            Genres = genres;
        }
    }


}

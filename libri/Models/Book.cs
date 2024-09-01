using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libri.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateOnly PublishedYear { get; set; }
        // * a *
        public List<Genre> Genres { get; set; } = new List<Genre>();


        public Book() { }

        public Book(string title, string author, DateOnly publishedYear)
        {
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
        }


    }
}

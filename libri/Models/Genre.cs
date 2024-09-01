using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libri.Models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        public Genre() { }
        public Genre(string name)
        {
            Name = name;
        }
    }
}

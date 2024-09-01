using libri.Models;
using Microsoft.EntityFrameworkCore;

namespace libri.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BooksDb;Integrated Security=True;Trust Server Certificate=True");
        }

      

    }
}

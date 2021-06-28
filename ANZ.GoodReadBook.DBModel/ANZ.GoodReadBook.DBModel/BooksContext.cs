using ANZ.GoodReadBook.DBModel.Model;
using Microsoft.EntityFrameworkCore;

namespace ANZ.GoodReadBook.DBModel
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ANZ.GoodReadBook.DBModel;
using ANZ.GoodReadBook.DBModel.Model;
using ANZ.GoodReadBook.DL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ANZ.GoodReadBook.DL
{
    public class BooksRepository : Repository<Books>, IBooksRepository
    {
        public BooksRepository(BooksContext context) : base(context)
        {
        }

        public IEnumerable<Books> GetTopAverageRatingByWriter()
        {
            var bookList = _context.Books.ToList();
            return bookList.GroupBy(x => x.Author, (key, g) => g.OrderByDescending(e => e.AverageRating).First());
        }
    }
}

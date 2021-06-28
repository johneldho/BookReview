using System.Collections.Generic;
using ANZ.GoodReadBook.DBModel.Model;
using ANZ.GoodReadBook.DL.Interface;
using System.Threading.Tasks;

namespace ANZ.GoodReadBook.BL
{
    public class BooksLogicLayer : IBooksLogicLayer
    {
        private readonly IBooksRepository _bookRepo;

        public BooksLogicLayer(IBooksRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IEnumerable<Books> GetTopAverageRatingByWriter()
        {
            return _bookRepo.GetTopAverageRatingByWriter();
        }
    }
}

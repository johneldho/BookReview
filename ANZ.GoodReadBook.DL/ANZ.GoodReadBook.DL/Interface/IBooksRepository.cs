using System.Collections.Generic;
using ANZ.GoodReadBook.DBModel.Model;
using System.Threading.Tasks;

namespace ANZ.GoodReadBook.DL.Interface
{
    public interface IBooksRepository : IRepository<DBModel.Model.Books>
    {
        IEnumerable<Books>  GetTopAverageRatingByWriter();
    }
}

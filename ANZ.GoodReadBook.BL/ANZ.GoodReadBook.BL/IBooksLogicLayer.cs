using ANZ.GoodReadBook.DBModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANZ.GoodReadBook.BL
{
    public interface IBooksLogicLayer
    {
        IEnumerable<Books> GetTopAverageRatingByWriter();
    }
}

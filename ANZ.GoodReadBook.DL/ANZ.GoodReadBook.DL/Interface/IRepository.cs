using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ANZ.GoodReadBook.DL.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
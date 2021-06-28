using ANZ.GoodReadBook.DBModel;
using ANZ.GoodReadBook.DL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANZ.GoodReadBook.DL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BooksContext _context;
        public Repository(BooksContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}

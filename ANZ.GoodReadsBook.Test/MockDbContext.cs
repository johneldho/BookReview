using System;
using System.ComponentModel.DataAnnotations;
using ANZ.GoodReadBook.DBModel;
using ANZ.GoodReadBook.DBModel.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ANZ.GoodReadsBook.Test
{
    public class MockDbContext
    {
        public  BooksContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<BooksContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BooksContext(options);

            context.Books.AddRange(
                new Books { BookId = 1, Title = "Unit Testing C#", Author = "A", AverageRating = "3.5" },
                new Books { BookId = 2, Title = "C# in Depth", Author = "A", AverageRating = "4.5" },
                new Books { BookId = 3, Title = "Java Head First", Author = "B", AverageRating = "3.5" },
                new Books { BookId = 4, Title = "SQl server in Depth ", Author = "B", AverageRating = "1.5" });

            context.SaveChanges();

            return context;
        }
    }
}

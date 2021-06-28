using ANZ.GoodReadBook.DBModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ANZ.GoodReadBook.DBModel
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new BooksContext( serviceProvider.GetRequiredService<DbContextOptions<BooksContext>>());

            // Look for any books.
            if (context.Books.Any())
            {
                return; // Data was already seeded
            }

            context.Books.AddRange(
                new Books {BookId = 1, Title = "Unit Testing C#", Author = "A", AverageRating = "3.5"},
                new Books {BookId = 2, Title = "C# in Depth", Author = "A", AverageRating = "4.5"},
                new Books {BookId = 3, Title = "Java Head First", Author = "B", AverageRating = "3.5"},
                new Books {BookId = 4, Title = "SQl server in Depth ", Author = "B", AverageRating = "1.5"});

            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANZ.GoodReadBook.DBModel;
using ANZ.GoodReadBook.DBModel.Model;

namespace ANZ.GoodReadsBook.IntegrationTest
{
    public static class SeedData
    {
        public static void PopulateTestData(BooksContext dbContext)
        {
            dbContext.Books.AddRange(
                new Books { BookId = 1, Title = "Unit Testing C#", Author = "A", AverageRating = "3.5" },
                new Books { BookId = 2, Title = "C# in Depth", Author = "A", AverageRating = "4.5" },
                new Books { BookId = 3, Title = "Java Head First", Author = "B", AverageRating = "3.5" },
                new Books { BookId = 4, Title = "SQl server in Depth ", Author = "B", AverageRating = "1.5" });

            dbContext.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using ANZ.GoodReadBook.DL;
using System.Linq;
using ANZ.GoodReadBook.DBModel;
using ANZ.GoodReadBook.DBModel.Model;
using Xunit;

namespace ANZ.GoodReadsBook.Test
{

    public class BooksRepositoryTest
    {
        MockDbContext mockDbContext;
        BooksContext context;

        public BooksRepositoryTest()
        {
            mockDbContext  = new MockDbContext();
            context = mockDbContext.GetContextWithData();
        }

        [Fact]
        public void GetTopAverageRatingByWriter_Pass()
        {
            var booksRepository = new BooksRepository(context);

            var topReview = booksRepository.GetTopAverageRatingByWriter();

            Assert.Equal(2, topReview.Count());
        }


        [Fact]
        public void CalculateVolume_Pass()
        {
            var booksRepository = new BooksRepository(context);
            var topReview = booksRepository.GetTopAverageRatingByWriter();

            var averageRating = topReview.Where(x => x.Author == "A").Select(x => x.AverageRating).FirstOrDefault();

            Assert.Equal("4.5",averageRating);
        }
    }
}

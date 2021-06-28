using ANZ.GoodReadBook.BL;
using ANZ.GoodReadBook.DBModel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ANZ.GoodReadsBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static ILogger<BookController> _logger;
        private readonly IBooksLogicLayer _booksLogicLayer;

        public BookController(ILogger<BookController> logger, IBooksLogicLayer booksLogicLayer)
        {
            _logger = logger;
            _booksLogicLayer = booksLogicLayer;
        }     

        /// <summary>
        /// Get top review of author 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Books> Get()
        {
            return _booksLogicLayer.GetTopAverageRatingByWriter();
        }
    }
}

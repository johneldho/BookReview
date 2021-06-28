using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ANZ.GoodReadBook.DBModel.Model
{
    public class Books
    {
        [Key]
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AverageRating { get; set; }
    }
}

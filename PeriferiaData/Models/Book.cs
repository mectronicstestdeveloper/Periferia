using System;
using System.Collections.Generic;

namespace PeriferiaData.Models
{
    public partial class Book
    {
        public Book()
        {
            BookCategory = new HashSet<BookCategory>();
        }

        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public DateTime BookReleaseDate { get; set; }
        public decimal BookPrice { get; set; }
        public Guid EditorialId { get; set; }

        public virtual Editorial Editorial { get; set; }
        public virtual ICollection<BookCategory> BookCategory { get; set; }
    }
}

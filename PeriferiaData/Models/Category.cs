using System;
using System.Collections.Generic;

namespace PeriferiaData.Models
{
    public partial class Category
    {
        public Category()
        {
            BookCategory = new HashSet<BookCategory>();
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<BookCategory> BookCategory { get; set; }
    }
}

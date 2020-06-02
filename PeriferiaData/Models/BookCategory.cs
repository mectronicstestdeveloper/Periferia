using System;
using System.Collections.Generic;

namespace PeriferiaData.Models
{
    public partial class BookCategory
    {
        public Guid BookCategoryId { get; set; }
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}

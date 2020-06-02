using System;
using System.Collections.Generic;

namespace PeriferiaData.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Book = new HashSet<Book>();
        }

        public Guid EditorialId { get; set; }
        public string EditorialName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}

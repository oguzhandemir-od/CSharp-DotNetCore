using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Domain.Entities
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Detail {  get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

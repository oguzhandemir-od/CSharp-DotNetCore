using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LibraryManagement.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public ushort PublicationYear { get; set; }
        public string Publisher { get; set; }
        public ushort PageCount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public bool IsAvailable { get; set; } = true;

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}

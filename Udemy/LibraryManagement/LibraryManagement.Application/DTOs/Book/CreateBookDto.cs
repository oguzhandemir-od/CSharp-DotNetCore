using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs.Book
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public ushort PublicationYear { get; set; }
        public string Publisher { get; set; }
        public ushort PageCount { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}

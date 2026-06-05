using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs
{
    public class ResultBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public ushort PublicationYear { get; set; }
        public ushort PageCount { get; set; }

        
        public string CategoryName { get; set; }
        public string AuthorFullName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.DTOs
{
    public class AuthorDto
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public int BooksCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.DTOs
{
    public class CreateBookDto
    {
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
    }
}

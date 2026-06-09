using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TotalBooks { get; set; }
        public List<string> BookNames { get; set; } = new List<string>();
    }
}

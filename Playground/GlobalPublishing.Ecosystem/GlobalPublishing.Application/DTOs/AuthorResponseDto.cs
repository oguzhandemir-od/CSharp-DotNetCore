using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.DTOs
{
    public record AuthorResponseDto(int Id, string FullName, int BooksCount);
    
}

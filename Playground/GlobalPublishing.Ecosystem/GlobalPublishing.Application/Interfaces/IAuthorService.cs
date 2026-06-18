using GlobalPublishing.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsWithCountAsync();
    }
}

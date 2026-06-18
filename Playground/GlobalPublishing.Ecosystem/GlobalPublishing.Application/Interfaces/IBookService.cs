using GlobalPublishing.Application.DTOs;
using GlobalPublishing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.Interfaces
{
    public interface IBookService
    {
        Task<int> AddBookAsync(CreateBookDto dto);
    }
}

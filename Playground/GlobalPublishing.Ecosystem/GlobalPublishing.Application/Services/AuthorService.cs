using GlobalPublishing.Application.DTOs;
using GlobalPublishing.Application.Interfaces;
using GlobalPublishing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IGenericRepository<Author> authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsWithCountAsync()
        {
            var query = _authorRepository.GetAll(false);

            var dtoQuery = query.Select(a=>new AuthorResponseDto(
                a.Id,
                a.FirstName+" "+a.LastName,
                a.Books.Count
                ));

            return await dtoQuery.ToListAsync();
        }
    }
}

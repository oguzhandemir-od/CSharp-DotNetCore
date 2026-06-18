using GlobalPublishing.Application.DTOs;
using GlobalPublishing.Application.Interfaces;
using GlobalPublishing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalPublishing.Application.Services
{
    public class BookService:IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IGenericRepository<Book> bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddBookAsync(CreateBookDto dto)
        {
            var book = new Book(dto.ISBN, dto.PageCount, 1);

            var bookTranslation = new BookTranslation(0, dto.LanguageId, dto.Title, dto.Description, 1);

            book.AddTranslation(bookTranslation);

            await _bookRepository.AddAsync(book);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}

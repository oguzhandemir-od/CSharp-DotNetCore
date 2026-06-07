using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetBooksWithAllDetailsAsync();

            var bookDtos = books.Select(b => new ResultBookDto
            {
                Id = b.Id,
                Name = b.Name,
                Publisher = b.Publisher,
                PublicationYear = b.PublicationYear,
                PageCount = b.PageCount,
                CategoryName = b.Category?.Name,
                AuthorFullName = b.Author != null ? $"{b.Author.Name} {b.Author.Surname}" : "Yazar Belirtilmemiş",
                IsAvailable=b.IsAvailable
            });

            return Ok(bookDtos);
        }

        [Authorize(Policy = "StaffOrMember")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetEntityByIdAsync(id);
            if (book == null)
                return NotFound();

            var bookDto = new ResultBookDto
            {
                Id = book.Id,
                Name = book.Name,
                Publisher = book.Publisher,
                PublicationYear = book.PublicationYear,
                PageCount = book.PageCount,
                CategoryName = book.Category?.Name,
                AuthorFullName = book.Author != null ? $"{book.Author.Name} {book.Author.Surname}" : "Yazar Belirtilmemiş"
            };

            return Ok(bookDto);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDto dto)
        {
            var book = new Book
            {
                Name = dto.Name,
                PublicationYear = dto.PublicationYear,
                Publisher = dto.Publisher,
                PageCount = dto.PageCount,
                CategoryId = dto.CategoryId,
                AuthorId = dto.AuthorId
            };

            await _bookRepository.AddEntityAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDto dto)
        {
            var existingBook=await _bookRepository.GetEntityByIdAsync(id);

            if (existingBook == null)
                return NotFound();

            existingBook.Name= dto.Name;
            existingBook.PublicationYear= dto.PublicationYear;
            existingBook.Publisher= dto.Publisher;
            existingBook.PageCount= dto.PageCount;
            existingBook.CategoryId= dto.CategoryId;
            existingBook.AuthorId= dto.AuthorId;

            await _bookRepository.UpdateEntityAsync(existingBook);
            return Ok(existingBook);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteEntityAsync(id);
            return NoContent();
        }

        [HttpGet("catalog")]
        [Authorize(Policy = "StaffOrMember")] 
        public async Task<IActionResult> GetCatalogBooks()
        {
            var catalogBooks = await _bookRepository.GetCatalogBooksAsync();

            return Ok(catalogBooks);
        }
    }
}

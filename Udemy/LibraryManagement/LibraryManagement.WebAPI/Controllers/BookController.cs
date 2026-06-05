using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetBooksAsync();

            var bookDtos = books.Select(b => new ResultBookDto
            {
                Id = b.Id,
                Name = b.Name,
                Publisher = b.Publisher,
                PublicationYear = b.PublicationYear,
                PageCount = b.PageCount,
                CategoryName = b.Category?.Name,
                AuthorFullName = b.Author != null ? $"{b.Author.Name} {b.Author.Surname}" : "Yazar Belirtilmemiş"
            });

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
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

            await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDto dto)
        {
            var existingBook=await _bookRepository.GetBookByIdAsync(id);

            if (existingBook == null)
                return NotFound();

            existingBook.Name= dto.Name;
            existingBook.PublicationYear= dto.PublicationYear;
            existingBook.Publisher= dto.Publisher;
            existingBook.PageCount= dto.PageCount;
            existingBook.CategoryId= dto.CategoryId;
            existingBook.AuthorId= dto.AuthorId;

            await _bookRepository.UpdateBookAsync(existingBook);
            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}

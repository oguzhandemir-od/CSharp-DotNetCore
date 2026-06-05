using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors= await _authorRepository.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Detail = dto.Detail
            };

            await _authorRepository.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthors), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto dto)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);

            if (existingAuthor == null)
                return NotFound();

            existingAuthor.Name = dto.Name;
            existingAuthor.Surname= dto.Surname;
            existingAuthor.Detail = dto.Detail;

            await _authorRepository.UpdateAuthorAsync(existingAuthor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorRepository.DeleteAuthorAsync(id);

            return NoContent();
        }
        
    }
}

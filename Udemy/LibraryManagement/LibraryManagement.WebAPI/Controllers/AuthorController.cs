using FluentValidation;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Staff;
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
        private readonly IValidator<AuthorDto> _validator;
        public AuthorController(IAuthorRepository authorRepository, IValidator<AuthorDto> validator)
        {
            _authorRepository = authorRepository;
            _validator= validator;
        }

        [Authorize(Policy = "StaffOrMember")]
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors= await _authorRepository.GetEntitiesAsync(a=>a.Books);

            var authorListDtos = authors.Select(author => new AuthorDto
            {
                Id=author.Id,
                Name = author.Name,
                Surname = author.Surname,
                Detail = author.Detail,

                // 🛠️ Yazarın silinmemiş kitaplarının sayısını alıyoruz
                TotalBooks = author.Books != null
            ? author.Books.Count(b => !b.IsDeleted)
            : 0,

                // 🛠️ Yazarın silinmemiş kitaplarının isimlerini listeliyoruz
                BookNames = author.Books != null
            ? author.Books.Where(b => !b.IsDeleted).Select(b => b.Name).ToList()
            : new List<string>()
            }).ToList();

            return Ok(authorListDtos);
        }

        [Authorize(Policy = "StaffOrMember")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetEntityByIdAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorDto dto)
        {     

            var author = new Author
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Detail = dto.Detail
            };

            await _authorRepository.AddEntityAsync(author);
            return CreatedAtAction(nameof(GetAuthors), new { id = author.Id }, author);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto dto)
        {
            var existingAuthor = await _authorRepository.GetEntityByIdAsync(id);

            if (existingAuthor == null)
                return NotFound();

            existingAuthor.Name = dto.Name;
            existingAuthor.Surname= dto.Surname;
            existingAuthor.Detail = dto.Detail;

            await _authorRepository.UpdateEntityAsync(existingAuthor);
            return Ok();
        }

        [Authorize(Policy = "AllStaff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorRepository.DeleteEntityAsync(id);

            return NoContent();
        }
        
    }
}

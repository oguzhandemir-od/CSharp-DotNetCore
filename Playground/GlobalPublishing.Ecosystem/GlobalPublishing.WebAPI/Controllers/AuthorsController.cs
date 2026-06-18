using GlobalPublishing.Application.DTOs;
using GlobalPublishing.Application.Interfaces;
using GlobalPublishing.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalPublishing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IGenericRepository<Author> authorRepository, IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var result = _authorService.GetAllAuthorsWithCountAsync();

            return Ok(result);
        }
    }
}

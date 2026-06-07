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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Authorize(Policy = "StaffOrMember")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetEntitiesAsync();
            return Ok(categories);
        }

        [Authorize(Policy = "StaffOrMember")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetEntityByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            await _categoryRepository.AddEntityAsync(category);
            return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto dto)
        {
            var existingCategory = await _categoryRepository.GetEntityByIdAsync(id);

            if (existingCategory == null)
                return NotFound("Güncellenmek istenen kategori bulunamadı.");

            existingCategory.Name= dto.Name;

            await _categoryRepository.UpdateEntityAsync(existingCategory);
            return Ok(new { message = "Kategori başarıyla güncellendi.", data = existingCategory });
        }

        [Authorize(Policy = "AllStaff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteEntityAsync(id);
            return NoContent();
        }
    }
}

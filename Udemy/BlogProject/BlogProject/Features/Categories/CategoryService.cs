using BlogProject.Domain.Entities;
using BlogProject.Features.Categories.DTOs;
using BlogProject.Features.Comments;
using BlogProject.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogProject.Features.Categories
{
    public class CategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Where(c=>!c.IsDeleted)
                .Select(c=>new CategoryDto
                {
                    Id= c.Id,
                    Name= c.Name
                })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return new CategoryDto { Id = category.Id, Name = category.Name };
        }

        //public async Task AddCategoryAsync(CategoryDto dto)
        //{
        //    var category = new Category
        //    {
        //        Name = dto.Name
        //    };

        //    _context.Categories.Add(category);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<ServiceResult> SaveOrUpdateCategoryAsync(CategoryDto categoryDto)
        {
            if (categoryDto.Id.HasValue && categoryDto.Id.Value > 0)
            {
                var category = await _context.Categories.FindAsync(categoryDto.Id);
                if (category == null)
                    return new ServiceResult { IsSuccess = false, Message = "Kategori bulunamadı!" };

                category.Name = categoryDto.Name;
            }
            else
            {
                var newCategory = new Category { Name = categoryDto.Name };
                await _context.Categories.AddAsync(newCategory);
            }

            await _context.SaveChangesAsync();
            return new ServiceResult { IsSuccess = true, Message = "Kategori başarıyla kaydedildi." };
        }

        //public async Task EditCategoryAsync(int id, CategoryDto dto)
        //{
        //    var existingCategory=await _context.Categories.FindAsync(id);

        //    if(existingCategory != null)
        //    {
        //        existingCategory.Name=dto.Name;
        //        _context.Categories.Update(existingCategory);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task<ServiceResult> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return new ServiceResult { IsSuccess = false, Message = "Kategori bulunamadı!" };

            
                category.IsDeleted = true;
                await _context.SaveChangesAsync();
            return new ServiceResult { IsSuccess = true, Message = "Kategori silindi." };
        }
    }
}

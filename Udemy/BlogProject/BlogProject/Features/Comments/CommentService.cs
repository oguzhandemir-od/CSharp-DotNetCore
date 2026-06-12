using BlogProject.Domain.Entities;
using BlogProject.Features.Account;
using BlogProject.Features.Categories.DTOs;
using BlogProject.Features.Comments.DTOs;
using BlogProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Features.Comments
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class CommentService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public CommentService(AppDbContext context,ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<AdminCommentDto>> GetAllCommentsAsync()
        {
            var query = _context.Comments.Where(c => !c.IsDeleted);

            if (_currentUserService.UserRole != "Admin")
            {
                query = query.Where(c => c.Post.AppUserId == _currentUserService.UserId);
            }

            return await query
                .Where(c => !c.IsDeleted)
                .Select(c => new AdminCommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    Username = c.User != null ? c.User.FullName : "Anonim",
                    PostTitle = c.Post.Title,
                    Status = c.Status.ToString(),
                    CreatedDate = c.CreatedDate,
                    IsDeleted = c.IsDeleted
                })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).FirstOrDefaultAsync();
        }

        public async Task<ServiceResult> UpdateStatusAsync(int id, string status)
        {
            var comment = await _context.Comments.Include(c => c.Post).FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null) return new ServiceResult { IsSuccess = false, Message = "Yorum bulunamadı!" };

            if (_currentUserService.UserRole != "Admin" && comment.Post.AppUserId != _currentUserService.UserId)
            {
                return new ServiceResult { IsSuccess = false, Message = "Bu yorumu yönetmeye yetkiniz yok!" };
            }

            if (Enum.TryParse(typeof(CommentStatus), status, out var parsedStatus))
            {
                comment.Status = (CommentStatus)parsedStatus;
                await _context.SaveChangesAsync();
                return new ServiceResult { IsSuccess = true, Message = "Yorum durumu güncellendi." };
            }
            return new ServiceResult { IsSuccess = false, Message = "Geçersiz durum." };
        }

        public async Task AddCommentAsync(CreateCommentDto dto)
        {
            var comment = new Comment
            {
                Content=dto.Content,
                PostId = dto.PostId,

                UserId = _currentUserService.IsAuthenticated ? _currentUserService.UserId : null,

                CreatedDate = DateTime.UtcNow,

                Status = CommentStatus.Pending,

                IsDeleted = false

            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(int id, CategoryDto dto)
        {
            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory != null)
            {
                existingCategory.Name = dto.Name;
                _context.Categories.Update(existingCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null && !category.IsDeleted)
            {
                category.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}


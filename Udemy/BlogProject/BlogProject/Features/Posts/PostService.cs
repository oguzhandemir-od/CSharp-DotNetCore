using BlogProject.Domain.Entities;
using BlogProject.Features.Account;
using BlogProject.Features.Comments;
using BlogProject.Features.Comments.DTOs;
using BlogProject.Features.Page.DTOs;
using BlogProject.Features.Posts.DTOs;
using BlogProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Features.Posts
{
    public class PostService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public PostService(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<PostViewDto>> GetPublicPostsAsync()
        {
            return await _context.Posts
                .Where(p => !p.IsDeleted && p.Status == PostStatus.Published) 
                .OrderByDescending(p => p.CreatedDate) 
                .Select(p => new PostViewDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Image = p.Image,
                    CreatedDate = p.CreatedDate,
                    AuthorName = p.AppUser.FullName ?? "Anonim",
                    CategoryName = p.Category.Name,
                    CommentCount = p.Comments.Count(c => !c.IsDeleted && c.Status == CommentStatus.Approved)
                }).ToListAsync();
        }

        public async Task<List<PostViewDto>> GetDashboardPostsAsync()
        {
            var query = _context.Posts.Where(p => !p.IsDeleted);

            if (_currentUserService.UserRole != "Admin")
            {
                query = query.Where(p => p.AppUserId == _currentUserService.UserId);
            }

            return await query
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new PostViewDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content, 
                    Image = p.Image,
                    CreatedDate = p.CreatedDate,
                    AuthorName = p.AppUser.FullName ?? "Anonim",
                    CategoryName = p.Category.Name,
                    CommentCount = p.Comments.Count(c => !c.IsDeleted && c.Status == CommentStatus.Approved)
                }).ToListAsync();
        }

        //public async Task<List<GetPostDto>> GetAllPostsAsync()
        //{
        //    return await _context.Posts
        //        .Where(p => !p.IsDeleted)
        //        .Select(p => new GetPostDto
        //        {
        //            Title = p.Title,
        //            Content = p.Content,
        //            Image = p.Image,
        //            CreatedDate = p.CreatedDate,
        //            AuthorName=p.AppUser.FullName ?? "Anonim",
        //            CategoryName=p.Category.Name,
        //            CommentCount=p.Comments.Count(c=>!c.IsDeleted && c.Status==CommentStatus.Approved)
        //        }).ToListAsync();
        //}

        public async Task<PostViewDto?> GetPostByIdAsync(int id)
        {
            return await _context.Posts
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new PostViewDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Image = p.Image,
                    CreatedDate = p.CreatedDate,
                    AuthorName = p.AppUser.FullName ?? "Anonim",
                    CategoryName = p.Category.Name,
                    CommentCount = p.Comments.Count(c => !c.IsDeleted && c.Status == CommentStatus.Approved),
                    Comments = p.Comments
                        .Where(c => !c.IsDeleted && c.Status == CommentStatus.Approved)
                        .Select(c => new GetCommentDto
                        {
                            Content = c.Content,
                            Username = c.User != null ? c.User.UserName : "Anonim Ziyaretçi",
                            CreatedDate = c.CreatedDate
                        }).ToList()
                }).FirstOrDefaultAsync();
        }

        //public async Task AddPostAsync(CreatePostDto dto)
        //{
        //    var post = new Post
        //    {
        //        Title = dto.Title,
        //        Content = dto.Content,
        //        Image = dto.Image,
        //        CategoryId = dto.CategoryId,

        //        CreatedDate = DateTime.UtcNow,
        //        Status = PostStatus.Published,
        //        IsDeleted = false,

        //        AppUserId = "1"
        //    };

        //    _context.Posts.Add(post);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdatePostAsync(int id, UpdatePostDto dto)
        //{
        //    var existingPost = await _context.Posts.FindAsync(id);

        //    if(existingPost!=null)
        //    {
        //        existingPost.Title=dto.Title;
        //        existingPost.Content=dto.Content;
        //        existingPost.Image=dto.Image;
        //        existingPost.CategoryId=dto.CategoryId;

        //        _context.Update(existingPost);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task<PostDto?> GetPostForEditAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null || post.IsDeleted) return null;

            if (_currentUserService.UserRole != "Admin" && post.AppUserId != _currentUserService.UserId)
                return null;

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Image = post.Image,
                CategoryId = post.CategoryId
            };
        }

        public async Task<ServiceResult> SaveOrUpdatePostAsync(PostDto dto)
        {
            if (dto.Id.HasValue && dto.Id.Value > 0)
            {
                var existingPost = await _context.Posts.FindAsync(dto.Id.Value);
                if (existingPost == null || existingPost.IsDeleted)
                    return new ServiceResult { IsSuccess = false, Message = "Düzenlenmek istenen makale bulunamadı." };

                if (_currentUserService.UserRole != "Admin" && existingPost.AppUserId != _currentUserService.UserId)
                    return new ServiceResult { IsSuccess = false, Message = "Bu makaleyi düzenleme yetkiniz yoktur!" };

                existingPost.Title = dto.Title;
                existingPost.Content = dto.Content;
                existingPost.Image = dto.Image;
                existingPost.CategoryId = dto.CategoryId;
            }
            else
            {
                var post = new Post
                {
                    Title = dto.Title,
                    Content = dto.Content,
                    Image = dto.Image,
                    CategoryId = dto.CategoryId,
                    Status = PostStatus.Published,
                    AppUserId = _currentUserService.UserId! 
                };
                await _context.Posts.AddAsync(post);
            }

            await _context.SaveChangesAsync();
            return new ServiceResult { IsSuccess = true, Message = "Makale başarıyla kaydedildi." };
        }

        public async Task<ServiceResult> DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null || post.IsDeleted)
            {
                return new ServiceResult { IsSuccess = false, Message = "Silinmek istenen makale bulunamadı." };
            }

            if (_currentUserService.UserRole != "Admin" && post.AppUserId != _currentUserService.UserId)
            {
                return new ServiceResult { IsSuccess = false, Message = "Bu makaleyi silmeye yetkiniz bulunmamaktadır!" };
            }

            post.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new ServiceResult { IsSuccess = true, Message = "Makale başarıyla silindi." };
        }

        public async Task<PagedResult<PostViewDto>> GetPagedPostsAsync(int page, int pageSize = 10)
        {
            var query = _context.Posts
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedDate);

            var totalItems = await query.CountAsync();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PostViewDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Image = p.Image,
                    CreatedDate = p.CreatedDate,
                    AuthorName = p.AppUser.FullName ?? "Anonim",
                    CategoryName = p.Category.Name,
                    CommentCount = p.Comments.Count(c => !c.IsDeleted && c.Status == CommentStatus.Approved)
                })
                .ToListAsync();

            return new PagedResult<PostViewDto>
            {
                Items = items,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }

    }
}

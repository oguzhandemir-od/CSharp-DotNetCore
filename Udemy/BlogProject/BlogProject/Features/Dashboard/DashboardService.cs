using BlogProject.Domain.Entities;
using BlogProject.Features.Dashboard.DTOs;
using BlogProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Features.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardHeaderDto> GetDashboardStatsAsync(string userId, bool isAdmin);
    }

    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context; 

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardHeaderDto> GetDashboardStatsAsync(string userId, bool isAdmin)
        {
            var dto = new DashboardHeaderDto { IsAdmin = isAdmin };

            if (isAdmin)
            {
                dto.TotalPosts = await _context.Posts.CountAsync(p => !p.IsDeleted);
                dto.TotalUsers = await _context.Users.CountAsync();
                dto.PendingCommentsCount = await _context.Comments.CountAsync(c => c.Status == CommentStatus.Pending );

                // Son hareketler (Global)
                var recentComments = await _context.Comments
                    .OrderByDescending(c => c.CreatedDate)
                    .Take(3)
                    .Select(c => new RecentActivityDto { Title = "Yeni Yorum", Description = $"{c.User.UserName}: {c.Content.Substring(0, Math.Min(c.Content.Length, 30))}...", Type = "Comment", TimeAgo = "Az önce" })
                    .ToListAsync();

                var recentPosts = await _context.Posts
                    .OrderByDescending(p => p.CreatedDate)
                    .Take(2)
                    .Select(p => new RecentActivityDto { Title = "Yeni Makale", Description = p.Title, Type = "Post", TimeAgo = "Bugün" })
                    .ToListAsync();

                dto.RecentActivities.AddRange(recentComments);
                dto.RecentActivities.AddRange(recentPosts);
            }
            else
            {
                dto.MyPostsCount = await _context.Posts.CountAsync(p => p.AppUserId == userId && !p.IsDeleted);

                dto.MyTotalCommentsCount = await _context.Comments
                    .CountAsync(c => _context.Posts.Any(p => p.Id == c.PostId && p.AppUserId == userId));

                dto.RecentActivities = await _context.Posts
                    .Where(p => p.AppUserId == userId && !p.IsDeleted)
                    .OrderByDescending(p => p.CreatedDate)
                    .Take(5)
                    .Select(p => new RecentActivityDto { Title = "Yayınladığınız Makale", Description = p.Title, Type = "Post", TimeAgo = "Aktif" })
                    .ToListAsync();
            }

            return dto;
        }
    }
}

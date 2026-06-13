namespace BlogProject.Features.Dashboard.DTOs
{
    public class DashboardHeaderDto
    {
        public bool IsAdmin { get; set; }
        public string UserFullName { get; set; }

        // Admin İstatistikleri
        public int TotalPosts { get; set; }
        public int TotalUsers { get; set; }
        public int PendingCommentsCount { get; set; }

        // Yazar İstatistikleri
        public int MyPostsCount { get; set; }
        public int MyTotalCommentsCount { get; set; }

        // Son Aktiviteler
        public List<RecentActivityDto> RecentActivities { get; set; } = new();
    }

    public class RecentActivityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TimeAgo { get; set; }
        public string Type { get; set; } // "Post", "Comment", "User"
    }
}

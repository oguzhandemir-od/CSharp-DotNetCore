using System.Reflection.Metadata;

namespace BlogProject.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CommentStatus Status { get; set; } = CommentStatus.Pending;
        public bool IsDeleted { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

        
    }
}

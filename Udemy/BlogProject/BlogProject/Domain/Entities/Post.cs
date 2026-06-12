using System.Xml.Linq;

namespace BlogProject.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public PostStatus Status { get; set; }
        public bool IsDeleted { get; set; }

        public string AppUserId { get; set; }
        public int CategoryId { get; set; }

        public AppUser AppUser { get; set; } = null!;
        public Category Category { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

using BlogProject.Features.Comments.DTOs;

namespace BlogProject.Features.Posts.DTOs
{
    public class PostViewDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; } = "Anonim";
        public string CategoryName { get; set; } = "Kategorisiz";
        public int CommentCount { get; set; }

        public List<GetCommentDto> Comments { get; set; } = new();
    }
}

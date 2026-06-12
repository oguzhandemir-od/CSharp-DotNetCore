namespace BlogProject.Features.Comments.DTOs
{
    public class GetCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Username { get; set; }
    }
}

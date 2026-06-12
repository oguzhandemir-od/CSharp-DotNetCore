namespace BlogProject.Features.Comments.DTOs
{
    public class AdminCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string Username { get; set; }

        public string PostTitle { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}

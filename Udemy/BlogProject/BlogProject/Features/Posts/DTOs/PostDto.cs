using System.ComponentModel.DataAnnotations;

namespace BlogProject.Features.Posts.DTOs
{
    public class PostDto
    {
        public int? Id { get; set; } 

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string? Image { get; set; }
        public int CategoryId { get; set; }

    }
}

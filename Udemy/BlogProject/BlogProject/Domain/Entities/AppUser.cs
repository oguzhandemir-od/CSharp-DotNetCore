using Microsoft.AspNetCore.Identity;

namespace BlogProject.Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public string? FullName { get; set; } 
        public string? ImageUrl { get; set; } 
        public string? About { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}

namespace BlogProject.Features.Users.DTOs
{
    public class UserViewDto
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!; 
        public int PostCount { get; set; } 
    }
}

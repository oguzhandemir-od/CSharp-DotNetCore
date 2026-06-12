using System.ComponentModel.DataAnnotations;

namespace BlogProject.Features.Account.DTOs
{
    public class LoginDto
    {
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

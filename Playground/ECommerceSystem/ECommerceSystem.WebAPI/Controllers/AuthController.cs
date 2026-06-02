using ECommerceSystem.Application.DTOs;
using ECommerceSystem.Application.Interfaces;
using ECommerceSystem.Domain.Entities;
using ECommerceSystem.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public AuthController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt=passwordSalt,
                Role=Enum.Parse<RoleEnum>(request.Role)
            };

            await _userRepository.AddEntityAsync(newUser);
            return Ok("Kullanıcı başarıyla kaydedildi!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
                return BadRequest("Kullanıcı bulunamadı.");

            var isPasswordValid = _authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

            if (!isPasswordValid)
                return BadRequest("Hatalı şifre.");

            var token = _authService.CreateToken(user);

            return Ok(new { Token = token });
        }
    }
}

using BlogProject.Domain.Entities;
using BlogProject.Features.Account.DTOs;
using BlogProject.Features.Comments;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Features.Account
{
    public class AccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ServiceResult> RegisterAsync(RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                return new ServiceResult { IsSuccess = false, Message = "Şifreler birbiriyle uyuşmuyor." };
            }

            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
            {
                return new ServiceResult { IsSuccess = false, Message = "Bu e-posta adresi zaten kullanımda." };
            }

            var newUser = new AppUser
            {
                FullName = dto.FullName,
                UserName = dto.Username,
                Email = dto.Email,
                EmailConfirmed = true 
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
                return new ServiceResult { IsSuccess = false, Message = errorMessage };
            }

            await _userManager.AddToRoleAsync(newUser, "Member");

            return new ServiceResult { IsSuccess = true, Message = "Kayıt işlemi başarıyla tamamlandı. Giriş yapabilirsiniz." };
        }

    }

}

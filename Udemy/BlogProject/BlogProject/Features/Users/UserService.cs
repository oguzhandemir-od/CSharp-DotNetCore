using BlogProject.Domain.Entities;
using BlogProject.Features.Comments;
using BlogProject.Features.Users.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Features.Users
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserViewDto>> GetAdminUsersAsync()
        {
            var users = await _userManager.Users
                .Where(u => !u.IsDeleted)
                .Include(u => u.Posts)
                .ToListAsync();
                

            var userListDto = new List<UserViewDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                userListDto.Add(new UserViewDto
                {
                    Id = user.Id,
                    FullName = user.FullName ?? "İsimsiz Kullanıcı",
                    Username = user.UserName ?? "",
                    Email = user.Email ?? "",
                    Role = roles.FirstOrDefault() ?? "Member", 
                    PostCount = user.Posts.Count
                });
            }

            return userListDto;
        }

        public async Task<ServiceResult> UpdateUserAsync(string id, string fullName, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || user.IsDeleted)
                return new ServiceResult { IsSuccess = false, Message = "Kullanıcı bulunamadı!" };

            if (id == user.Id && role != "Admin")
            {
                return new ServiceResult { IsSuccess = false, Message = "Kendi yöneticilik yetkinizi (Admin rolünü) düşüremezsiniz!" };
            }

            user.FullName = fullName;
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                var errors = string.Join(" ", updateResult.Errors.Select(e => e.Description));
                return new ServiceResult { IsSuccess = false, Message = $"Kullanıcı güncellenemedi: {errors}" };
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeResult.Succeeded)
                return new ServiceResult { IsSuccess = false, Message = "Mevcut roller temizlenirken bir hata oluştu." };

            var addResult = await _userManager.AddToRoleAsync(user, role);
            if (!addResult.Succeeded)
                return new ServiceResult { IsSuccess = false, Message = "Yeni rol atanırken bir hata oluştu." };

            return new ServiceResult { IsSuccess = true, Message = "Kullanıcı bilgileri ve yetkisi başarıyla güncellendi." };
        }

        public async Task<ServiceResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return new ServiceResult { IsSuccess = false, Message = "Silinmek istenen kullanıcı bulunamadı!" };

            if (user.IsDeleted)
                return new ServiceResult { IsSuccess = false, Message = "Bu kullanıcı zaten daha önce silinmiş." };

            user.IsDeleted = true; 
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return new ServiceResult { IsSuccess = false, Message = "Kullanıcı silinirken veritabanı hatası oluştu." };

            return new ServiceResult { IsSuccess = true, Message = "Kullanıcı başarıyla silindi (Pasife çekildi)." };
        }
    }
}


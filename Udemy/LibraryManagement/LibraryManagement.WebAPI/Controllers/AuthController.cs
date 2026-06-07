using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Member;
using LibraryManagement.Application.DTOs.Staff;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Application.Services;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGenericRepository<Staff> _staffRepository;
        private readonly IGenericRepository<Member> _memberRepository;
        private readonly IAuthService _authService;

        public AuthController(
            IGenericRepository<Staff> staffRepository,
            IGenericRepository<Member> memberRepository,
            IAuthService authService)
        {
            _staffRepository = staffRepository;
            _memberRepository = memberRepository;
            _authService = authService;
        }

        #region Member Auth (Üye Giriş/Kayıt)

        [HttpPost("register/member")]
        public async Task<IActionResult> RegisterMember(MemberRegisterDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newMember = new Member
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _memberRepository.AddEntityAsync(newMember);
            return Ok("Üye kaydı başarıyla tamamlandı!");
        }

        [HttpPost("login/member")]
        public async Task<IActionResult> LoginMember(LoginDto request)
        {
            var members = await _memberRepository.GetEntitiesAsync();
            var member = members.FirstOrDefault(m => m.Email == request.Email);

            if (member == null)
                return BadRequest("Üye bulunamadı.");

            var isPasswordValid = _authService.VerifyPasswordHash(request.Password, member.PasswordHash, member.PasswordSalt);
            if (!isPasswordValid)
                return BadRequest("Hatalı şifre.");

            
            var token = _authService.CreateToken(member.Id, member.Email, "Member");
            return Ok(new { Token = token });
        }

        #endregion

        #region Staff Auth (Personel Giriş/Kayıt)

        [Authorize(Policy = "ManagerOnly")]
        [HttpPost("register/staff")]
        public async Task<IActionResult> RegisterStaff(StaffRegisterDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newStaff = new Staff
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _staffRepository.AddEntityAsync(newStaff);
            return Ok("Personel kaydı başarıyla tamamlandı!");
        }

        [HttpPost("login/staff")]
        public async Task<IActionResult> LoginStaff(LoginDto request)
        {
            var staffs = await _staffRepository.GetEntitiesAsync();
            var staff = staffs.FirstOrDefault(s => s.Email == request.Email);

            if (staff == null)
                return BadRequest("Personel bulunamadı.");

            var isPasswordValid = _authService.VerifyPasswordHash(request.Password, staff.PasswordHash, staff.PasswordSalt);
            if (!isPasswordValid)
                return BadRequest("Hatalı şifre.");

            string staffType = (staff.Id == 6 || staff.Email == "admin@kutuphane.com") ? "Manager" : "Officer";

            var token = _authService.CreateToken(staff.Id, staff.Email, "Staff", staffType);
            return Ok(new { Token = token });
        }

        #endregion

        #region Change Password (Şifre Değiştirme)

        [HttpPut("change-password/member")]
        [Authorize(Policy = "LibraryMemberOnly")]
        public async Task<IActionResult> ChangeMemberPassword(ChangePasswordDto request)
        {
            var memberId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var member = await _memberRepository.GetEntityByIdAsync(memberId);
            if (member == null) return NotFound("Üye bulunamadı.");

            var isOldPasswordValid = _authService.VerifyPasswordHash(request.OldPassword, member.PasswordHash, member.PasswordSalt);
            if (!isOldPasswordValid)
                return BadRequest("Mevcut şifrenizi hatalı girdiniz.");

            _authService.CreatePasswordHash(request.NewPassword, out byte[] newHash, out byte[] newSalt);
            member.PasswordHash = newHash;
            member.PasswordSalt = newSalt;

            await _memberRepository.UpdateEntityAsync(member);
            return Ok("Şifreniz başarıyla güncellendi.");
        }

        [HttpPut("change-password/staff")]
        [Authorize(Policy = "LibraryStaffOnly")]
        public async Task<IActionResult> ChangeStaffPassword(ChangePasswordDto request)
        {
            var staffId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var staff = await _staffRepository.GetEntityByIdAsync(staffId);
            if (staff == null) return NotFound("Personel bulunamadı.");

            var isOldPasswordValid = _authService.VerifyPasswordHash(request.OldPassword, staff.PasswordHash, staff.PasswordSalt);
            if (!isOldPasswordValid)
                return BadRequest("Mevcut şifrenizi hatalı girdiniz.");

            _authService.CreatePasswordHash(request.NewPassword, out byte[] newHash, out byte[] newSalt);
            staff.PasswordHash = newHash;
            staff.PasswordSalt = newSalt;

            await _staffRepository.UpdateEntityAsync(staff);
            return Ok("Şifreniz başarıyla güncellendi.");
        }

        #endregion
    }
}

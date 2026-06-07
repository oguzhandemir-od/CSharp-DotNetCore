using LibraryManagement.Application.DTOs.Member;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [Authorize(Policy = "AllStaff")]
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _memberRepository.GetMembersWithAllDetailsAsync();

            var memberDtos = members.Select(m => new MemberResultDto
            {
                Id = m.Id,
                Name = m.Name,
                Surname = m.Surname,
                Email = m.Email,

                Loans = m.Loans.Select(l => new MemberLoanDto
                {
                    BookTitle = l.Book != null ? l.Book.Name : "Bilinmeyen Kitap",
                    LoanDate = l.LoanDate,
                    DueDate = l.DueDate,
                    ReturnDate = l.ReturnDate,
                    IsReturned = l.IsReturned
                }).ToList(),

                Penalties=m.Penalties.Select(p=> new MemberPenaltyDto
                {
                    Amount = p.Amount,
                    IsPaid = p.IsPaid,
                    PenaltyDate = p.PenaltyDate
                }).ToList()
            }).ToList();
            return Ok(memberDtos);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member=await _memberRepository.GetEntityByIdAsync(id);

            if (member == null)
                return NotFound();

            var memberDto = new MemberResultDto
            {
                Name = member.Name,
                Surname = member.Surname,
                Email = member.Email
            };

            return Ok(memberDto);
        }

        [HttpGet("profile")]
        [Authorize(Policy = "LibraryMemberOnly")] 
        public async Task<IActionResult> GetMyProfile()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            int memberId = int.Parse(userIdClaim.Value);

            var member = await _memberRepository.GetEntityByIdAsync(memberId);
            if (member == null) return NotFound("Profil bulunamadı.");

            var memberDto = new MemberResultDto
            {
                Name = member.Name,
                Surname = member.Surname,
                Email = member.Email
            };

            return Ok(memberDto);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddMember(MemberCreateDto dto)
        //{
        //    var member = new Member
        //    {
        //        Name = dto.Name,
        //        Surname = dto.Surname,
        //        Email = dto.Email,

        //        PasswordHash=Array.Empty<byte>(),
        //        PasswordSalt=Array.Empty<byte>()
        //    };

        //    await _memberRepository.AddEntityAsync(member);
        //    return Ok();
        //}

        [Authorize(Policy = "StaffOrMember")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, MemberCreateDto dto)
        {
            var existingMember = await _memberRepository.GetEntityByIdAsync(id);

            if (existingMember == null)
                return NotFound();

            existingMember.Name = dto.Name;
            existingMember.Surname = dto.Surname;
            existingMember.Email= dto.Email;

            _memberRepository.UpdateEntityAsync(existingMember);
            return Ok();
        }

        [Authorize(Policy = "AllStaff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            await _memberRepository.DeleteEntityAsync(id);
            return NoContent();
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPost("pay-penalty/{penaltyId}")]
        public async Task<IActionResult> PayPenalty(int penaltyId)
        {
            var isUpdated = await _memberRepository.PaySinglePenaltyAsync(penaltyId);

            if (!isUpdated)
            {
                return BadRequest(new { message = "Ceza bulunamadı veya zaten ödenmiş." });
            }

            return Ok(new { message = "Seçilen ceza başarıyla tahsil edildi." });
        }

        [Authorize(Policy = "AllStaff")] 
        [HttpPost("pay-all/{id}")]
        public async Task<IActionResult> PayAllPenalties(int id)
        {
            var isUpdated = await _memberRepository.PayAllPenaltiesAsync(id);

            if (!isUpdated)
            {
                return BadRequest(new { message = "Bu üyeye ait aktif (ödenmemiş) bir ceza kaydı bulunamadı." });
            }

            return Ok(new { message = "Üyenin tüm cezaları başarıyla tahsil edildi ve sıfırlandı." });
        }
    }
}

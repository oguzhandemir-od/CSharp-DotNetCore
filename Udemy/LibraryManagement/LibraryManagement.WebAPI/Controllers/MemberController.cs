using LibraryManagement.Application.DTOs.Member;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
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

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _memberRepository.GetMembersWithAllDetailsAsync();

            var memberDtos = members.Select(m => new MemberResultDto
            {
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

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberCreateDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,

                PasswordHash=Array.Empty<byte>(),
                PasswordSalt=Array.Empty<byte>()
            };

            await _memberRepository.AddEntityAsync(member);
            return Ok();
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            await _memberRepository.DeleteEntityAsync(id);
            return NoContent();
        }
    }
}

using LibraryManagement.Application.DTOs.Loan;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Application.Services;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly ILoanRepository _loanRepository;

        public LoanController(ILoanService loanService, ILoanRepository loanRepository)
        {
            _loanService = loanService;
            _loanRepository = loanRepository;
        }

        [Authorize(Policy = "AllStaff")]
        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var result = await _loanService.GetAllLoansWithDetailsAsync();
            return Ok(result);
        }

        [HttpGet("my-loans")]
        [Authorize(Policy = "LibraryMemberOnly")] 
        public async Task<IActionResult> GetMyLoans()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Geçersiz veya süresi dolmuş token.");

            int currentMemberId = int.Parse(userIdClaim.Value);

            var allLoans = await _loanRepository.GetEntitiesAsync(l=>l.Book);

            var myLoans = allLoans
                .Where(l => l.MemberId == currentMemberId)
                .OrderByDescending(l => l.LoanDate) 
                .Select(l => new
                {
                    l.Id,
                    l.BookId,
                    BookName= l.Book != null ? l.Book.Name : "Bilinmeyen Kitap",
                    LoanDate = l.LoanDate.ToString("yyyy-MM-dd"),
                    DueDate = l.DueDate.ToString("yyyy-MM-dd"),
                    ReturnDate = l.ReturnDate.HasValue ? l.ReturnDate.Value.ToString("yyyy-MM-dd") : "Teslim Edilmedi",
                    l.IsReturned,
                    StaffName=$"{l.Staff.Name} {l.Staff.Surname}"
                })
                .ToList();

            return Ok(myLoans);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] LoanCreateDto dto)
        {
            var result = await _loanService.CreateLoanAsync(dto);

            if (result.Contains("bulunamadı") || result.Contains("verilemez") || result.Contains("gecikmiş"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Policy = "AllStaff")]
        [HttpPut("return")]
        public async Task<IActionResult> ReturnBook([FromBody] LoanReturnDto dto)
        {
            var result = await _loanService.ReturnBookAsync(dto);

            if (result.Contains("bulunamadı") || result.Contains("daha önce"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

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

        [Authorize(Policy = "LibraryStaffOnly")]
        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var result = await _loanService.GetAllLoansWithDetailsAsync();
            return Ok(result);
        }

        [HttpGet("my-loans")]
        [Authorize(Policy = "LibraryMemberOnly")] // Sadece kütüphane üyeleri erişebilir
        public async Task<IActionResult> GetMyLoans()
        {
            // 1. Token'dan giriş yapmış üyenin ID'sini çekiyoruz
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Geçersiz veya süresi dolmuş token.");

            int currentMemberId = int.Parse(userIdClaim.Value);

            // 2. Veri tabanından tüm ödünç işlemlerini çekiyoruz
            var allLoans = await _loanRepository.GetEntitiesAsync();

            // 3. Sadece bu üyeye ait olanları LINQ ile filtreliyoruz
            // NOT: Eğer Repository katmanında Include yapabiliyorsan Book bilgisini de dahil etmek şık olur.
            var myLoans = allLoans
                .Where(l => l.MemberId == currentMemberId)
                .OrderByDescending(l => l.LoanDate) // En yeni ödünç alınanlar en üstte görünsün
                .Select(l => new
                {
                    l.Id,
                    l.BookId,
                    // l.Book?.Name gibi (Eğer Include ile yüklüyorsan kitap adını da dönebilirsin)
                    LoanDate = l.LoanDate.ToString("yyyy-MM-dd"),
                    DueDate = l.DueDate.ToString("yyyy-MM-dd"),
                    ReturnDate = l.ReturnDate.HasValue ? l.ReturnDate.Value.ToString("yyyy-MM-dd") : "Teslim Edilmedi",
                    l.IsReturned
                })
                .ToList();

            return Ok(myLoans);
        }

        [Authorize(Policy = "LibraryStaffOnly")]
        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] LoanCreateDto dto)
        {
            var result = await _loanService.CreateLoanAsync(dto);

            // Eğer dönen mesaj başarı içermiyorsa bad request dönüyoruz
            if (result.Contains("bulunamadı") || result.Contains("verilemez") || result.Contains("gecikmiş"))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Policy = "LibraryStaffOnly")]
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

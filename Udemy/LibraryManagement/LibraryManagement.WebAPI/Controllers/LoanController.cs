using LibraryManagement.Application.DTOs.Loan;
using LibraryManagement.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var result = await _loanService.GetAllLoansWithDetailsAsync();
            return Ok(result);
        }

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

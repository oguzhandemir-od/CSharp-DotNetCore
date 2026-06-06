using LibraryManagement.Application.DTOs.Loan;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Services
{
    public interface ILoanService
    {
        Task<string> CreateLoanAsync(LoanCreateDto dto);
        Task<IEnumerable<LoanResultDto>> GetAllLoansWithDetailsAsync();
        Task<string> ReturnBookAsync(LoanReturnDto dto);
    }
}

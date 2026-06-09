using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Authorize(Policy = "AllStaff")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<Member> _memberRepository;
        private readonly IGenericRepository<Loan> _loanRepository;
        private readonly IGenericRepository<Penalty> _penaltyRepository;

        public StatsController(
            IGenericRepository<Book> bookRepository,
            IGenericRepository<Member> memberRepository,
            IGenericRepository<Loan> loanRepository,
            IGenericRepository<Penalty> penaltyRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _loanRepository = loanRepository;
            _penaltyRepository = penaltyRepository;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardStats()
        {
            // 1. Tüm listeleri asenkron olarak veritabanından çekiyoruz
            var books = await _bookRepository.GetEntitiesAsync();
            var members = await _memberRepository.GetEntitiesAsync();
            var loans = await _loanRepository.GetEntitiesAsync();
            var penalties = await _penaltyRepository.GetEntitiesAsync();

            // 2. Üst Sayaç Kartlarının Hesaplamaları
            int totalBooks = books.Count();
            int totalMembers = members.Count();
            int activeLoans = loans.Count(l => !l.IsReturned);

            // Ödenmemiş (IsPaid == false) cezaların toplam tutarı
            decimal totalUnpaidPenalties = penalties.Where(p => !p.IsPaid).Sum(p => p.Amount);

            // 3. Son Ödünç Verilen 5 Kitap (İlişkisel verileri güvenli bağlama)
            var recentLoans = loans
                .OrderByDescending(l => l.LoanDate)
                .Take(5)
                .Select(l => new RecentLoanDto
                {
                    LoanId = l.Id,
                    BookName = l.Book?.Name ?? "Bilinmeyen Kitap",
                    MemberFullName = l.Member != null ? $"{l.Member.Name} {l.Member.Surname}" : "Bilinmeyen Üye",
                    LoanDate = l.LoanDate,
                    StaffFullName = l.Staff != null ? $"{l.Staff.Name} {l.Staff.Surname}" : "Sistem"
                })
                .ToList();

            // 4. Süresi Geciken ve Henüz Teslim Edilmeyen Kitaplar
            var now = DateTime.UtcNow;
            var overdueLoans = loans
                .Where(l => !l.IsReturned && l.DueDate < now)
                .Select(l => new OverdueLoanDto
                {
                    LoanId = l.Id,
                    BookName = l.Book?.Name ?? "Bilinmeyen Kitap",
                    MemberFullName = l.Member != null ? $"{l.Member.Name} {l.Member.Surname}" : "Bilinmeyen Üye",
                    DueDate = l.DueDate,
                    DelayDays = (now - l.DueDate).Days // Gecikme gün sayısı hesabı
                })
                .OrderByDescending(o => o.DelayDays) // En çok gecikenden en aza
                .ToList();

            // 5. Hazırladığımız DTO'yu Frontend'e tek bir paket halinde fırlatıyoruz
            var dashboardData = new DashboardStatsDto
            {
                TotalBooks = totalBooks,
                TotalMembers = totalMembers,
                ActiveLoans = activeLoans,
                TotalUnpaidPenalties = totalUnpaidPenalties,
                RecentLoans = recentLoans,
                OverdueLoans = overdueLoans
            };

            return Ok(dashboardData);
        }
    }
}

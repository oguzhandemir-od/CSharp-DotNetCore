using LibraryManagement.Application.DTOs.Loan;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IGenericRepository<Loan> _loanRepository;
        private readonly IGenericRepository<Penalty> _penaltyRepository;

        public LoanService(IGenericRepository<Book> bookRepository, IMemberRepository memberRepository, IGenericRepository<Loan> loanRepository,
            IGenericRepository<Penalty> penaltyRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _loanRepository = loanRepository;
            _penaltyRepository = penaltyRepository;
        }



        public async Task<string> CreateLoanAsync(LoanCreateDto dto)
        {
            var book = await _bookRepository.GetEntityByIdAsync(dto.BookId);

            if (book == null) return "Kitap bulunamadı.";

            if (!book.IsAvailable)
            {
                return "Bu kitap şu an başka bir üyede, ödünç verilemez!";
            }

            var member = await _memberRepository.GetMembersWithAllDetailsAsync();
            var currentMember = member.FirstOrDefault(m => m.Id == dto.MemberId);

            if (currentMember == null) return "Üye bulunamadı.";

            bool hasDelayedBook = currentMember.Loans.Any(l => !l.IsReturned && l.DueDate < DateTime.UtcNow);
            if (hasDelayedBook) return "Üyenin elinde gecikmiş kitap var! Önce onu teslim etmeli.";

            var loan = new Loan
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                StaffId = dto.StaffId,
                LoanDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(15),
                IsReturned = false
            };

            book.IsAvailable = false;
            await _bookRepository.UpdateEntityAsync(book);

            await _loanRepository.AddEntityAsync(loan);
            return "Kitap başarıyla ödünç verildi. Son teslim tarihi: " + loan.DueDate.ToShortDateString();
        }

        public async Task<IEnumerable<LoanResultDto>> GetAllLoansWithDetailsAsync()
        {
            var loans = await _loanRepository.GetEntitiesAsync(l => l.Book, l => l.Member, l=>l.Staff);

            return loans.Select(l => new LoanResultDto
            {
                BookName = l.Book != null ? l.Book.Name : "Bilinmeyen Kitap",
                MemberFullName = l.Member != null ? $"{l.Member.Name} {l.Member.Surname}" : "Bilinmeyen Üye",
                LoanDate = l.LoanDate,
                DueDate = l.DueDate,
                IsReturned = l.IsReturned,
                StaffName = l.Staff != null ? $"{l.Staff.Name} {l.Staff.Surname}" : "Bilinmeyen Personel"
            }).ToList();
        }

        public async Task<string> ReturnBookAsync(LoanReturnDto dto)
        {
            var loan = await _loanRepository.GetEntityByIdAsync(dto.LoanId);

            if (loan == null) return "Ödünç kaydı bulunamadı.";
            if (loan.IsReturned) return "Bu kitap zaten daha önce iade edilmiş.";

            var book = await _bookRepository.GetEntityByIdAsync(loan.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
                await _bookRepository.UpdateEntityAsync(book);
            }

            DateTime today = DateTime.UtcNow;
            string message = "Kitap zamanında iade edildi. Teşekkürler.";

            if (today.Date > loan.DueDate.Date)
            {
                int delayedDays = (today.Date - loan.DueDate.Date).Days;

                if (delayedDays > 0)
                {
                    decimal dailyPenaltyAmount = 5.0m;
                    decimal totalPenalty = delayedDays * dailyPenaltyAmount;

                    var penalty = new Penalty
                    {
                        LoanId = loan.Id,
                        MemberId = loan.MemberId,
                        Amount = totalPenalty,
                        PenaltyDate = today,
                        IsPaid = false
                    };

                    await _penaltyRepository.AddEntityAsync(penalty);

                    message = $"Kitap {delayedDays} gün gecikti! Hesaplanan Ceza: {totalPenalty} TL. Ceza kaydı oluşturuldu.";
                }
            }

            loan.IsReturned = true;
            loan.ReturnDate = today;

            await _loanRepository.UpdateEntityAsync(loan);

            return message;
        }
    }
}

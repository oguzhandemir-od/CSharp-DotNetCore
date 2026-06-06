using FluentValidation;
using LibraryManagement.Application.DTOs.Loan;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Validators
{
    public class LoanCreateDtoValidator : AbstractValidator<LoanCreateDto>
    {
        public LoanCreateDtoValidator()
        {
            RuleFor(x => x.MemberId)
                .NotEmpty().WithMessage("Ödünç alacak üye seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir üye ID'si girilmelidir.");

            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("Ödünç verilecek kitap seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir kitap ID'si girilmelidir.");

            RuleFor(x => x.StaffId)
                .NotEmpty().WithMessage("İşlemi gerçekleştiren personel seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir personel ID'si girilmelidir.");
        }
    }
}

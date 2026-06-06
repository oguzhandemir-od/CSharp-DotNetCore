using FluentValidation;
using LibraryManagement.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Validators
{
    public class MemberCreateDtoValidator : AbstractValidator<MemberCreateDto>
    {
        public MemberCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Üye adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Üye adı en fazla 50 karakter olabilir.")
                .MinimumLength(2).WithMessage("Üye adı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Üye soyadı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Üye soyadı en fazla 50 karakter olabilir.")
                .MinimumLength(2).WithMessage("Üye soyadı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.")
                .MaximumLength(100).WithMessage("E-posta adresi en fazla 100 karakter olabilir.");
        }
    }
}

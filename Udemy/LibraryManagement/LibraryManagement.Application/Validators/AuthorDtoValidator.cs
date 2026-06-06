using FluentValidation;
using LibraryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Validators
{
    public class AuthorDtoValidator: AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Yazar adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olabilir.")
                .MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karakter olabilir.")
                .MinimumLength(2).WithMessage("Yazar soyadı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Detail)
                .MaximumLength(500).WithMessage("Yazar detay açıklaması en fazla 500 karakter olabilir.");
        }
    }
}

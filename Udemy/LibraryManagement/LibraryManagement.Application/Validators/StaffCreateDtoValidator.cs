using FluentValidation;
using LibraryManagement.Application.DTOs.Staff;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Validators
{
    public class StaffCreateDtoValidator : AbstractValidator<StaffCreateDto>
    {
        public StaffCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Personel soyadı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel soyadı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş bırakılamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");
        }
    }
}

using FluentValidation;
using LibraryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olabilir.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
        }
    }
}

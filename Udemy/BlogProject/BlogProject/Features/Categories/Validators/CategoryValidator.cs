using BlogProject.Features.Categories.DTOs;
using FluentValidation;

namespace BlogProject.Features.Categories.Validators
{
    public class CategoryValidator:AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("kategori adı boş bırakılamaz.")
                .NotNull().WithMessage("kategori adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("kategori adı en fazla 15 karakter olmalıdır.") 
                .Must(name => name.Trim().Length <= 15).WithMessage("kategori adı en fazla 15 karakter olabilir.");
        }
    }
}

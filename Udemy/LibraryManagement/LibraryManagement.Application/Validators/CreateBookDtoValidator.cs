using FluentValidation;
using LibraryManagement.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.Validators
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kitap adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Kitap adı en fazla 150 karakter olabilir.")
                .MinimumLength(2).WithMessage("Kitap adı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("Yayıncı/Yayınevi alanı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Yayınevi adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.PageCount)
                .NotEmpty().WithMessage("Sayfa sayısı boş bırakılamaz.")
                .GreaterThan((ushort)0).WithMessage("Sayfa sayısı 0'dan büyük olmalıdır.");

            RuleFor(x => x.PublicationYear)
                .NotEmpty().WithMessage("Yayın yılı boş bırakılamaz.")
                .GreaterThan((ushort)1000).WithMessage("Geçerli bir yayın yılı giriniz (1000'den büyük).")
                .LessThanOrEqualTo((ushort)DateTime.UtcNow.Year).WithMessage($"Yayın yılı içinde bulunduğumuz yıldan ({DateTime.UtcNow.Year}) büyük olamaz.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir kategori ID'si girilmelidir.");

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Yazar seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Geçerli bir yazar ID'si girilmelidir.");
        }
    }
}

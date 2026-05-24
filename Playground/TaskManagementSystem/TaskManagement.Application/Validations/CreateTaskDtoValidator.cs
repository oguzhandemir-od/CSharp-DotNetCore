using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.DTOs;
using FluentValidation;

namespace TaskManagement.Application.Validations
{
    public class CreateTaskDtoValidator:AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Görev başlığı boş bırakılamz.")
                .MaximumLength(100).WithMessage("Görev başlığı en fazla 100 karakter olabilir");

            RuleFor(dto => dto.DueDate)
                .NotEmpty().WithMessage("Teslim tarihi boş bırakılamaz.")
                .GreaterThan(DateTime.Now).WithMessage("Teslim tarihi geçmiş bir tarih olamaz.");
        }
    }
}

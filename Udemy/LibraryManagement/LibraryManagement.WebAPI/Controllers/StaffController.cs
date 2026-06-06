using AutoMapper;
using FluentValidation;
using LibraryManagement.Application.DTOs.Staff;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.WebAPI.Controllers
{
    [Authorize(Policy = "LibraryStaffOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IGenericRepository<Staff> _staffRepository;
        private readonly IValidator<StaffCreateDto> _validator;

        public StaffController(IGenericRepository<Staff> staffRepository, IValidator<StaffCreateDto> validator)
        {
            _staffRepository = staffRepository;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staffList = await _staffRepository.GetEntitiesAsync();

            var result = staffList.Select(s => new StaffResultDto
            {
                Id = s.Id,
                FullName = $"{s.Name} {s.Surname}",
                Email = s.Email
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] StaffCreateDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            var staff = new Staff
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PasswordHash = Array.Empty<byte>(),
                PasswordSalt = Array.Empty<byte>()
            };

            await _staffRepository.AddEntityAsync(staff);
            return StatusCode(201, "Personel başarıyla eklendi.");
        }


    }
}

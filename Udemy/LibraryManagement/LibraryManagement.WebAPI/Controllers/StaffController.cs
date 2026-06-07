using AutoMapper;
using FluentValidation;
using LibraryManagement.Application.DTOs.Member;
using LibraryManagement.Application.DTOs.Staff;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.WebAPI.Controllers
{
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

        [Authorize(Policy = "AllStaff")]
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

        [Authorize(Policy = "AllStaff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _staffRepository.GetEntityByIdAsync(id);

            if (staff == null)
                return NotFound();

            var staffDto = new StaffResultDto
            {
                Id = id,
                FullName=$"{staff.Name} {staff.Surname}",
                Email=staff.Email
            };

            return Ok(staffDto);
        }

        [Authorize(Policy = "ManagerOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, StaffCreateDto dto)
        {
            var existingStaff = await _staffRepository.GetEntityByIdAsync(id);

            if (existingStaff == null)
                return NotFound();

            existingStaff.Name = dto.Name;
            existingStaff.Surname = dto.Surname;
            existingStaff.Email = dto.Email;

            await _staffRepository.UpdateEntityAsync(existingStaff);
            return Ok();
        }

        [Authorize(Policy = "ManagerOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            await _staffRepository.DeleteEntityAsync(id);
            return NoContent();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateStaff([FromBody] StaffCreateDto dto)
        //{
        //    var validationResult = await _validator.ValidateAsync(dto);

        //    if (!validationResult.IsValid)
        //    {
        //        var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        //        return BadRequest(errors);
        //    }

        //    var staff = new Staff
        //    {
        //        Name = dto.Name,
        //        Surname = dto.Surname,
        //        Email = dto.Email,
        //        PasswordHash = Array.Empty<byte>(),
        //        PasswordSalt = Array.Empty<byte>()
        //    };

        //    await _staffRepository.AddEntityAsync(staff);
        //    return StatusCode(201, "Personel başarıyla eklendi.");
        //}


    }
}

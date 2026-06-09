using AutoMapper;
using AutoMapperPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("test")]
        public IActionResult GetTestUser()
        {
            var fakeUser = new User
            {
                Id = 1,
                FirstName = "Can",
                LastName = "Yılmaz",
                Email = "can@yilmaz.com",
                PasswordHash = "secret_hash_12345", 
                CreatedAt = DateTime.Now
            };

            var userDto = _mapper.Map<UserDto>(fakeUser);

            return Ok(userDto);
        }

        [HttpPost("simulate-save")]
        public IActionResult SimulateSave([FromBody] UserCreateDto createDto)
        {
            var incomingUserEntity = _mapper.Map<User>(createDto);

            incomingUserEntity.Id = new Random().Next(10, 100); // Sahte ID
            incomingUserEntity.PasswordHash = "BCRYPT_SIMULATED_" + createDto.Password; 
            incomingUserEntity.CreatedAt = DateTime.Now;

            var responseDto = _mapper.Map<UserDto>(incomingUserEntity);

            return Ok(new
            {
                Message = "Veri başarıyla alındı, Entity'ye dönüştürüldü ve tekrar güvenli DTO olarak yanıtlandı!",
                Result = responseDto
            });
        }
    }
}

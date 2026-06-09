using AutoMapper;
using AutoMapperPrototype;
using AutoMapperPrototype.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AutoMapperPrototype.Tests
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            var services = new ServiceCollection();

            services.AddLogging();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        [Fact] 
        public void User_Should_Map_To_UserDto_Correctly()
        {
            var sourceUser = new User
            {
                Id = 1,
                FirstName = "Can",
                LastName = "Yılmaz",
                Email = "can@yilmaz.com",
                PasswordHash = "secret_123"
            };

            var resultDto = _mapper.Map<UserDto>(sourceUser);

            Assert.NotNull(resultDto); 
            Assert.Equal(1, resultDto.Id); 
            Assert.Equal("Can Yılmaz", resultDto.FullName); 
            Assert.Equal("can@yilmaz.com", resultDto.Email); 
        }

        [Theory]
        [InlineData("Ahmet", "Yılmaz", "ahmet@gmail.com")]
        [InlineData("Zeynep", "Kaya", "zeynep@hotmail.com")]
        [InlineData("Ayşe", "Demir", "ayse@outlook.com")]
        public void User_Should_Map_With_Different_Inputs(string firstName, string lastName, string email)
        {
            var sourceUser = new User
            {
                Id = new Random().Next(1, 100),
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            var resultDto = _mapper.Map<UserDto>(sourceUser);

            Assert.Equal($"{firstName} {lastName}", resultDto.FullName);
            Assert.Equal(email, resultDto.Email);
        }
    }
}

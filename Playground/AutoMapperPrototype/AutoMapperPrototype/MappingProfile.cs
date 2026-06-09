using AutoMapper;
using AutoMapperPrototype.Models;

namespace AutoMapperPrototype
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UserDto, User>();

            CreateMap<UserCreateDto, User>();
        }
    }
}

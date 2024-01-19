using AutoMapper;
using Jwt.DTOs;
using Jwt.Models;
using Jwt.Services.DTOs;

namespace Jwt.Services.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => src.Roles.Select(r=>r.Id))
                )
                .ReverseMap();

            CreateMap<SignUpDto, User>();
        }
    }
}

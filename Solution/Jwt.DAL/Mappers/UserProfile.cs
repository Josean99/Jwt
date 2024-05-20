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
            CreateMap<UserRequestDto, User>()
                .ForMember(
                    dest => dest.Roles,
                    opt => opt.Ignore());

            CreateMap<User, UserResponseDto>();
            CreateMap<SignUpDto, User>();

        }
    }
}

using AutoMapper;
using Jwt.DTOs;
using Jwt.Models;

namespace Jwt.Services.Mappers
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<RoleRequestDto, Role>()
                .ForMember(
                    dest => dest.Methods,
                    opt => opt.MapFrom(src => new List<Method>())
                )
                .ReverseMap();

            CreateMap<Role, RoleResonseDto>()
                .ReverseMap();
        }
    }
}

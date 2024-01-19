using AutoMapper;
using Jwt.DTOs;
using Jwt.Models;

namespace Jwt.Services.Mappers
{
    public class MethodProfile : Profile
    {
        public MethodProfile()
        {
            CreateMap<MethodRequestDto, Method>()
                .ReverseMap();

            CreateMap<Method, MethodResponseDto>()
                .ReverseMap();

        }
    }
}

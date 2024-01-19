using AutoMapper;
using Jwt.DTOs;
using Jwt.Models;

namespace Jwt.Services.Mappers
{
    public class MicroserviceProfile : Profile
    {
        public MicroserviceProfile()
        {
            CreateMap<MicroserviceRequestDto, Microservice>()
                .ReverseMap();

            CreateMap<Microservice, MicroserviceResponseDto>()
                .ReverseMap();
        }
    }
}

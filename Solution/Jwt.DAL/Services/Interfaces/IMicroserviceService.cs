using Jwt.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IMicroserviceService
    {
        Task<MicroserviceResponseDto> Post(MicroserviceRequestDto dto);
        Task<List<MicroserviceResponseDto>> GetAll();
    }
}
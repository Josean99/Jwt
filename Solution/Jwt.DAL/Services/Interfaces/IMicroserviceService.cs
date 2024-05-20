using Jwt.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IMicroserviceService
    {
        Task<MicroserviceResponseDto> Post(MicroserviceRequestDto dto);
        Task<MicroserviceResponseDto> Put(MicroserviceRequestDto dto);
        Task<bool> SoftDelete(Guid id);
        Task<List<MicroserviceResponseDto>> GetAll();
    }
}
using Jwt.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IMethodService
    {
        Task<MethodResponseDto> Post(MethodRequestDto dto);
        Task<List<MethodResponseDto>> GetByMicroservice(Guid id);
        Task<List<MethodResponseDto>> GetByRole(Guid id);
        Task<List<MethodResponseDto>> GetForLogin(List<Guid> roles, Guid idMicroservice);
    }
}
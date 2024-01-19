using Jwt.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IRolesService
    {
        Task<RoleResonseDto> Post(RoleRequestDto dto);
    }
}
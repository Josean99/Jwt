using Jwt.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IRolesService
    {
        Task<RoleResonseDto> Post(RoleRequestDto dto);
        Task<RoleResonseDto> Put(RoleRequestDto dto);
        Task<bool> SoftDelete(Guid id);
        Task<List<RoleResonseDto>> GetAll();
        Task<List<RoleResonseDto>> GetUserRoles(Guid idUser);
    }
}
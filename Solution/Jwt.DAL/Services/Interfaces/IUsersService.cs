using Jwt.DTOs;
using Jwt.Services.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IUsersService
    {
        Task<UserDto> Get(Guid id);
        Task<List<string>> GetAllowedMethods(GetAllowedMethodsDto dto);
        Task<string?> LogInUser(LoginUserDto dto);
        Task<UserDto> SignUpUser(SignUpDto dto);
        Task<UserDto> AssociateRoles(Guid idUser, List<Guid> roles);
    }
}
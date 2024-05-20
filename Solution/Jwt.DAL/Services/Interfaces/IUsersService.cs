using Jwt.DTOs;
using Jwt.Services.DTOs;

namespace Jwt.Services.Services.Interfaces
{
    public interface IUsersService
    {
        Task<UserResponseDto> Get(Guid id);
        Task<List<UserResponseDto>> GetAll();
        Task<List<string>> GetAllowedMethods(GetAllowedMethodsDto dto);
        Task<UserResponseDto> Post(UserRequestDto dto);
        Task<UserResponseDto> Put(UserRequestDto dto);
        Task<bool> SoftDelete(Guid id);
        Task<bool> ResetPassword(Guid idUser);
        Task<string?> LogInUser(LoginUserDto dto);
        Task<UserResponseDto> SignUpUser(SignUpDto dto);
        Task<UserResponseDto> AssociateRoles(Guid idUser, List<Guid> roles);
    }
}
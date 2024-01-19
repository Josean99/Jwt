using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record RoleResonseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<MethodResponseDto> Methods { get; set; }
    }
}

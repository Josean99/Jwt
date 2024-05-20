using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record RoleRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Methods { get; set; } = new List<Guid>();
    }
}

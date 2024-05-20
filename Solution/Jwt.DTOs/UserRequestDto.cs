using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record UserRequestDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public IList<Guid> Roles { get; set; }
    }
}

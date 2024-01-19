using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record MicroserviceRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

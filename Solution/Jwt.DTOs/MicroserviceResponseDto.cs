using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record MicroserviceResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<MethodResponseDto> Methods { get; set; }
    }
}

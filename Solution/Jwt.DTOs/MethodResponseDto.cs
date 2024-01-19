using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record MethodResponseDto
    {
        public Guid Id { get; set; }
        public string Verb { get; set; }
        public string Path { get; set; }
        public MicroserviceResponseDto Microservice { get; set; }
    }
}

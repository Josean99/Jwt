using Jwt.Services.DTOs;

namespace Jwt.DTOs
{
    public record MethodRequestDto
    {
        public Guid Id { get; set; }
        public string Verb { get; set; }
        public string Path { get; set; }
        public Guid? IdMicroservice { get; set; }
    }
}

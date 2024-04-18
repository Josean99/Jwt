using Jwt.Services.DTOs;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace Jwt.DTOs
{
    public record MicroserviceRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? SwaggerContract { get; set; }
    }
}

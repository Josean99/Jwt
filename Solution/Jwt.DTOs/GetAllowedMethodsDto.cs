namespace Jwt.Services.DTOs
{
    public class GetAllowedMethodsDto
    {
        public Guid idMicroservice { get; set; }
        public string token { get; set; }
    }
}

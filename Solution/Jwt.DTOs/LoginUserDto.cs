namespace Jwt.Services.DTOs
{
    public record LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

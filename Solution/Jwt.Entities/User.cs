namespace Jwt.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? FechaBaja { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}

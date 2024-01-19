namespace Jwt.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? FechaBaja { get; set; }

        public List<User> Users { get; set; }
        public List<Method> Methods { get; set; }
    }
}
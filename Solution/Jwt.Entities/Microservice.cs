namespace Jwt.Models
{
    public class Microservice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? FechaBaja { get; set; }

        public ICollection<Method> Methods { get; set; }
    }
}
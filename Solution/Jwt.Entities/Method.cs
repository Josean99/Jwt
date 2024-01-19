namespace Jwt.Models
{
    public class Method
    {
        public Guid Id { get; set; }
        public string Verb { get; set; }
        public string Path { get; set; }
        public Guid? IdMicroservice { get; set; }
        public DateTime? FechaBaja { get; set; }

        public Microservice? Microservice { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}

namespace TP3.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? MembershipType_id { get; set; }

        public MembershipType? MembershipType { get; set; }

        public ICollection<Movie>? Movies { get; set; }

    }
}

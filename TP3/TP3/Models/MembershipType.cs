using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class MembershipType
    {
        public Guid Id { get; set; }

        public float SignUpFee {  get; set; }

        public int DurationInMonth { get; set; }

        public decimal DiscountRate { get; set; }

        public ICollection<Customer>? Customers { get; set; }

    }
}

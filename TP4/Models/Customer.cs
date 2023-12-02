using System.ComponentModel.DataAnnotations.Schema;

namespace TP4.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        [ForeignKey("MembershiptypeId")]
        public int? Membershiptypeid { get; set; }

        // Navigation
        public virtual Membershiptype? Membershiptypes { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}

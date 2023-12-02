using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public string? Name { get; set; }


        public ICollection<Movie>? Movies { get; set; }
    }
}

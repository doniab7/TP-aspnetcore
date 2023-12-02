namespace TP2.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid? GenreId { get; set; }

        public virtual Genre? Genre { get; set; }


    }
}

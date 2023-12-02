namespace TP4.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        // Navigation
        public List<Movie>? Movies { get; set; }
    }
}

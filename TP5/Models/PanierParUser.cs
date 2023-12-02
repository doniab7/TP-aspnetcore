namespace TP5.Models
{
    public class PanierParUser
    {
        public Guid Id { get; set; }
        public string? UserID { get; set; }
        public Guid ProductId { get; set; }
        public List<Product>? products { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace TP4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Membershiptype>? Membershiptypes { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {

            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("GenreSeedData.Json");
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            if( genres != null)
                foreach (Genre c in genres)
                    model.Entity<Genre>().HasData(c);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Movie> movies { get; set; }

        public DbSet<MembershipType> membershiptypes { get; set; }
        public DbSet<Genre> genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string genreJson = System.IO.File.ReadAllText("genre.json");
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(genreJson);

            if (genres != null)
            {
                foreach (Genre c in genres)
                    modelBuilder.Entity<Genre>().HasData(c);
            }
        }

    }
}

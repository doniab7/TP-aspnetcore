using Microsoft.EntityFrameworkCore;

namespace TP2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options) 
        {

        }

        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre> genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
        }


    }

    
}

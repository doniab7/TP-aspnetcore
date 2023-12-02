using Microsoft.EntityFrameworkCore;
using TP4.Models;
using TP4.Repositories.RepositoryContracts;

namespace TP4.Repositories.Reository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Movie> GetAllMovies()
        {
            return _db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                movie.Photo = $"/images/{movie.ImageFile.FileName}";
            }

            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _db.Movies.Find(id);

            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _db.Movies
                .Where(m => m.GenresId == genreId)
                .ToList();
        }

        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _db.Movies
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return _db.Movies
                .Where(m => m.Genres.GenreName == userDefinedGenre)
                .ToList();
        }
    }
}

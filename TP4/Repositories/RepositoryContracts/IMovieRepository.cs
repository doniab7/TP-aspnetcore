using TP4.Models;

namespace TP4.Repositories.RepositoryContracts
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void EditMovie(Movie movie);
        void DeleteMovie(int id);
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetAllMoviesOrderedAscending();
        List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre);
    }
}

using Movies.Services.Models;

namespace Movies.Services.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> CreateMovie(Movie movie);

        Task<Movie> UpdateMovie(Movie movie);

        Task<Movie?> GetMovie(int movieId);

        Task<IEnumerable<Movie>> GetMovies();

        Task DeleteMovie(int movieId);
    }
}

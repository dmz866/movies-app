using Movies.Services.Models;

namespace Movies.Services.Interfaces
{
    public interface IMovieRatingService
    {
        Task<MovieRating> CreateMovieRating(MovieRating movieRating);

        Task<MovieRating> UpdateMovieRating(MovieRating movieRating);

        Task<MovieRating?> GetMovieRating(int movieRatingId);

        Task<IEnumerable<MovieRating>> GetMovieRatings(int movieId);

        Task DeleteMovieRating(int movieRatingId);
    }
}

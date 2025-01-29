using Microsoft.EntityFrameworkCore;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Movies.Services
{
    public class MovieRatingService : BaseService<MoviesContext>, IMovieRatingService
    {
        public MovieRatingService(MoviesContext context) : base(context)
        {
        }

        public async Task<MovieRating> CreateMovieRating(MovieRating movieRating)
        {            
            var model = await _context.MovieRatings.AddAsync(movieRating);
            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public async Task DeleteMovieRating(int movieRatingId)
        {
            var movierating = await GetMovieRating(movieRatingId);

            if (movierating == null) 
            {
                throw new Exception($"MovieRating {movieRatingId} not found");
            }

            _context.MovieRatings.Remove(movierating);
            await _context.SaveChangesAsync();
        }

        public async Task<MovieRating?> GetMovieRating(int movieRatingId)
        {
            return await _context.MovieRatings
               .Where(u => u.MovieRatingId.Equals(movieRatingId))
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MovieRating>> GetMovieRatings(int movieId)
        {
            return await _context.MovieRatings
                    .Where(m => m.MovieId.Equals(movieId))
                    .ToListAsync();
        }

        public async Task<MovieRating> UpdateMovieRating(MovieRating movierating)
        {
            var model = _context.MovieRatings.Update(movierating);
            await _context.SaveChangesAsync();

            return model.Entity;
        }
    }
}
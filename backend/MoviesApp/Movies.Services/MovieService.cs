using System.Linq;
using Microsoft.EntityFrameworkCore;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Movies.Services
{
    public class MovieService : BaseService<MoviesContext>, IMovieService
    {
        private readonly IMovieRatingService _movieRatingService;

        public MovieService(MoviesContext context, IMovieRatingService movieRatingService) : base(context)
        {
            _movieRatingService = movieRatingService;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            var model = await _context.Movies.AddAsync(movie);

            if (movie.MovieRatings != null && movie.MovieRatings.Any())
            {
                foreach (var movieRating in movie.MovieRatings)
                {
                    await _movieRatingService.CreateMovieRating(movieRating);
                }
            }

            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public async Task DeleteMovie(int movieId)
        {
            var movie = await GetMovie(movieId);

            if (movie == null)
            {
                throw new Exception($"Movie {movieId} not found");
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie?> GetMovie(int movieId)
        {
            return await _context.Movies
                .Where(u => u.MovieId.Equals(movieId))
                .Select(a => new Movie { 
                    Name = a.Name,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    MovieId = a.MovieId,
                    Actors = _context.MovieActors.Where(ma => ma.MovieId.Equals(movieId)).Select(ma => ma.Actor).ToList(),
                    MovieRatings = _context.MovieRatings.Where(ma => ma.MovieId.Equals(movieId)).ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovies(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return await _context.Movies
                    .Include(a => a.Actors)
                    .Include(a => a.MovieRatings)
                    .Where(m => m.Name.Contains(name))
                    .ToListAsync();
            }

            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var model = _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return model.Entity;
        }
    }
}
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

        public async Task<int> DeleteMovie(int movieId)
        {
            var movie = await _context.Movies
                .Where(u => u.MovieId.Equals(movieId))                
                .FirstOrDefaultAsync();

            if (movie == null) return -1;

            DeleteMovieActors(movie.MovieId);
            DeleteMovieRatings(movie.MovieId);
            _context.Movies.Remove(movie);

            return await _context.SaveChangesAsync();
        }

        private void DeleteMovieActors(int movieId)
        {
            var movieMovies = _context.MovieActors.Where(ma => ma.MovieId.Equals(movieId));

            if (movieMovies != null && movieMovies.Any())
            {
                _context.MovieActors.RemoveRange(movieMovies);
            }
        }

        private void DeleteMovieRatings(int movieId)
        {
            var movieRatings = _context.MovieRatings.Where(ma => ma.MovieId.Equals(movieId));

            if (movieRatings != null && movieRatings.Any())
            {
                _context.MovieRatings.RemoveRange(movieRatings);
            }
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
                    .Where(m => m.Name.ToLower().Contains(name.ToLower()))
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
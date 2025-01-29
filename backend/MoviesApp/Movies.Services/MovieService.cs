using Microsoft.EntityFrameworkCore;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Movies.Services
{
    public class MovieService : BaseService<MoviesContext>, IMovieService
    {
        public MovieService(MoviesContext context) : base(context)
        {
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {            
            var model = await _context.Movies.AddAsync(movie);
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
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovies(string? name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                return await _context.Movies
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
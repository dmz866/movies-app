using Microsoft.EntityFrameworkCore;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Movies.Services
{
    public class MovieActorService : BaseService<MoviesContext>, IMovieActorService
    {        
        public MovieActorService(MoviesContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MovieActor>> AssignMoviesToActor(int actorId, int[] movieIds)
        {
            var actor = await _context.Actors.Where(a => a.ActorId.Equals(actorId)).FirstOrDefaultAsync();

            if (actor == null)
            {
                throw new Exception("Actor not found");
            }

            if (movieIds == null || movieIds.Length == 0)
            {
                throw new Exception("Movie list is empty");
            }

            var movieActors = new List<MovieActor>();

            foreach (var movieId in movieIds)
            {
                var movieActor = await _context.MovieActors.AddAsync(new MovieActor() { ActorId = actorId, MovieId = movieId });
                movieActors.Add(movieActor.Entity);
            }           

            await _context.SaveChangesAsync();

            return movieActors;
        }
    }
}
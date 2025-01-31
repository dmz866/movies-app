using Movies.Services.Models;

namespace Movies.Services.Interfaces
{
    public interface IMovieActorService
    {
        Task<IEnumerable<MovieActor>> AssignMoviesToActor(int actorId, int[] movieIds);
    }
}

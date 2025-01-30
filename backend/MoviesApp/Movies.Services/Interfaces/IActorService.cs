using Movies.Services.Models;

namespace Movies.Services.Interfaces
{
    public interface IActorService
    {
        Task<Actor> CreateActor(Actor actor);

        Task<Actor> UpdateActor(Actor actor);

        Task<Actor?> GetActor(int actorId);

        Task<IEnumerable<Actor>> GetActors(string? name);

        Task<int> DeleteActor(int actorId);
    }
}

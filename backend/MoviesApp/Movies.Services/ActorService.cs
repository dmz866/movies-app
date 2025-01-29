using Microsoft.EntityFrameworkCore;
using Movies.Services.Contexts;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Movies.Services
{
    public class ActorService : BaseService<MoviesContext>, IActorService
    {
        public ActorService(MoviesContext context) : base(context)
        {
        }

        public async Task<Actor> CreateActor(Actor actor)
        {
            var model = await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public async Task DeleteActor(int actorId)
        {
            var actor = await GetActor(actorId);

            if (actor == null)
            {
                throw new Exception($"Actor {actorId} not found");
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor?> GetActor(int actorId)
        {
            return await _context.Actors
               .Where(u => u.ActorId.Equals(actorId))
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> UpdateActor(Actor actor)
        {
            var model = _context.Actors.Update(actor);
            await _context.SaveChangesAsync();

            return model.Entity;
        }
    }
}
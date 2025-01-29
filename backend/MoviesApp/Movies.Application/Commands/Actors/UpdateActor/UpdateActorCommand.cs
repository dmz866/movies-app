using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Actors.UpdateActor
{
    public class UpdateActorCommand : IRequest<Actor>
    {
        public int ActorId { get; set; }

        public required string Name { get; set; }
    }
}

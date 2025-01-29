using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Actors.CreateActor
{
    public class CreateActorCommand : IRequest<Actor>
    {
        public int ActorId { get; set; }
    }
}

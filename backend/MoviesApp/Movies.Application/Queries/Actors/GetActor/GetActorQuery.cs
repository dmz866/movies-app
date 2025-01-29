using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Queries.Actors.GetActor
{
    public class GetActorQuery : IRequest<Actor?>
    {
        public int ActorId { get; set; }
    }
}

using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Actors.AssignMoviesToActor
{
    public class AssignMoviesToActorCommand : IRequest<IEnumerable<MovieActor>?>
    {
        public required int ActorId { get; set; }

        public required int[] MoviesIds { get; set; }
    }
}

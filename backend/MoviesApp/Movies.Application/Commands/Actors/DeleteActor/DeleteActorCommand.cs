using MediatR;

namespace Movies.Application.Commands.Actors.DeleteActor
{
    public class DeleteActorCommand : IRequest
    {
        public int ActorId { get; set; }
    }
}

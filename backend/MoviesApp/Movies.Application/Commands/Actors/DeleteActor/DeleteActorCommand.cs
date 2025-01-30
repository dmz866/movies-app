using MediatR;

namespace Movies.Application.Commands.Actors.DeleteActor
{
    public class DeleteActorCommand : IRequest<int>
    {
        public required int ActorId { get; set; }
    }
}

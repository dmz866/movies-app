using MediatR;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Actors.DeleteActor
{
    public class DeleteActorHandler : IRequestHandler<DeleteActorCommand>
    {
        private readonly IActorService _actorService;

        public DeleteActorHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            await _actorService.DeleteActor(request.ActorId);
        }
    }
}

using MediatR;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Actors.DeleteActor
{
    public class DeleteActorHandler : IRequestHandler<DeleteActorCommand, int>
    {
        private readonly IActorService _actorService;

        public DeleteActorHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<int> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            return await _actorService.DeleteActor(request.ActorId);
        }
    }
}

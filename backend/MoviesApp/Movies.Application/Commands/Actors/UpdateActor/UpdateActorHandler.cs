using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Actors.UpdateActor
{
    public class UpdateActorHandler : IRequestHandler<UpdateActorCommand, Actor>
    {
        private readonly IActorService _actorService;

        public UpdateActorHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<Actor> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _actorService.UpdateActor(request.ToModel());

            return actor.ToDomain();
        }
    }
}

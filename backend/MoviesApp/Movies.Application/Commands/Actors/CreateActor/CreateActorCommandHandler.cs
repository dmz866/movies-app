using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Actors.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Actor>
    {
        private readonly IActorService _actorService;

        public CreateActorCommandHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<Actor> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _actorService.CreateActor(request.ToModel());

            return actor.ToDomain();
        }
    }
}

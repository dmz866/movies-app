using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Actors.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Actor?>
    {
        private readonly IActorService _actorService;
        private readonly IMovieActorService _movieActorService;

        public CreateActorCommandHandler(IActorService actorService, IMovieActorService movieActorService)
        {
            _actorService = actorService;
            _movieActorService = movieActorService;
        }

        public async Task<Actor?> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _actorService.CreateActor(request.ToModel());

            if(actor != null && request.MoviesIds != null && request.MoviesIds.Length > 0)
            {
                await _movieActorService.AssignMoviesToActor(actor.ActorId, request.MoviesIds);
            }

            return actor?.ToDomain();
        }
    }
}

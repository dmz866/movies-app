using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Actors.AssignMoviesToActor
{
    public class AssignMoviesToActorCommandHandler : IRequestHandler<AssignMoviesToActorCommand, IEnumerable<MovieActor>?>
    {
        private readonly IMovieActorService _movieActorService;        
        
        public AssignMoviesToActorCommandHandler(IMovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }

        public async Task<IEnumerable<MovieActor>?> Handle(AssignMoviesToActorCommand request, CancellationToken cancellationToken)
        {
            var movieActors = await _movieActorService.AssignMoviesToActor(request.ActorId, request.MoviesIds);

            return null;
        }
    }
}

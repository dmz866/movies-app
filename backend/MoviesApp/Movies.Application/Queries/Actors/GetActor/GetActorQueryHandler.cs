using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Queries.Actors.GetActor
{
    public class GetActorHandler : IRequestHandler<GetActorQuery, Actor?>
    {
        private readonly IActorService _actorService;

        public GetActorHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<Actor?> Handle(GetActorQuery request, CancellationToken cancellationToken)
        {
            var actor = await _actorService.GetActor(request.ActorId);

            return actor?.ToDomain();
        }
    }
}

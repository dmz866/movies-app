using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Queries.Actors.GetActors
{
    public class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, IEnumerable<Actor>>
    {
        private readonly IActorService _actorService;

        public GetActorsQueryHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<IEnumerable<Actor>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
        {            
            var actors = await _actorService.GetActors();

            return actors.Select(m => m.ToDomain());
        }
    }
}

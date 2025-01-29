using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Queries.Actors.GetActors
{
    public class GetActorsQuery : IRequest<IEnumerable<Actor>>
    {        
        public string? Name { get; set; }
    }
}

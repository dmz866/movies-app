using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Queries.Movies.GetMovies
{
    public class GetMoviesQuery : IRequest<IEnumerable<Movie>>
    {        
        public string? Name { get; set; }
    }
}

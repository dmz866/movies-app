using MediatR;
using MoviesApp.Application.Entities;

namespace MoviesApp.Application.Queries.Movies.GetMovies
{
    public class GetMoviesQuery : IRequest<IEnumerable<Movie>>
    {        
    }
}

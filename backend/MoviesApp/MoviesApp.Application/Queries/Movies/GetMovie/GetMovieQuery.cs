using MediatR;
using MoviesApp.Application.Entities;

namespace MoviesApp.Application.Queries.Movies.GetMovie
{
    public class GetMovieQuery : IRequest<Movie?>
    {
        public int MovieId { get; set; }
    }
}

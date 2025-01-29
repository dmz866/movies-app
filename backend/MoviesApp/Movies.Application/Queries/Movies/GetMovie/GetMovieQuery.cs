using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Queries.Movies.GetMovie
{
    public class GetMovieQuery : IRequest<Movie?>
    {
        public int MovieId { get; set; }
    }
}

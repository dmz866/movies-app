using MediatR;
using MoviesApp.Application.Entities;

namespace MoviesApp.Application.Commands.Movies.UpdateMovie
{
    public class UpdateMovieCommand : IRequest<Movie>
    {
        public int MovieId { get; set; }
    }
}

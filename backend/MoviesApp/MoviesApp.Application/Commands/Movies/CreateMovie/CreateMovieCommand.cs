using MediatR;
using MoviesApp.Application.Entities;

namespace MoviesApp.Application.Commands.Movies.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public int MovieId { get; set; }
    }
}

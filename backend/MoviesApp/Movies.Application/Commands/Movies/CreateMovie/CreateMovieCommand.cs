using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Movies.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public int MovieId { get; set; }

        public string Name { get; set; }
    }
}

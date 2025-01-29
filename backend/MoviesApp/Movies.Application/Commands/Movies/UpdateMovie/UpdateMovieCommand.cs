using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Movies.UpdateMovie
{
    public class UpdateMovieCommand : IRequest<Movie>
    {
        public int MovieId { get; set; }

        public required string Name { get; set; }

        public IEnumerable<MovieRating>? MovieRatings { get; set; }
    }
}

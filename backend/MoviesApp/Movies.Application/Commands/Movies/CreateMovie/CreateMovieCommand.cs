using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Movies.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public int MovieId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public IEnumerable<Actor>? Actors { get; set; }

        public IEnumerable<MovieRating>? MovieRatings { get; set; }
    }
}

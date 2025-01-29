using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.MovieRatings.UpdateMovieRating
{
    public class UpdateMovieRatingCommand : IRequest<MovieRating>
    {
        public int MovieRatingId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required int MovieId { get; set; }
    }
}

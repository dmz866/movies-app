using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.MovieRatings.UpdateMovieRating
{
    public class UpdateMovieRatingCommand : IRequest<MovieRating>
    {
        public int MovieRatingId { get; set; }

        public decimal Value { get; set; }

        public required int MovieId { get; set; }
    }
}

using MediatR;

namespace Movies.Application.Commands.MovieRatings.DeleteMovieRating
{
    public class DeleteMovieRatingCommand : IRequest
    {
        public int MovieRatingId { get; set; }
    }
}

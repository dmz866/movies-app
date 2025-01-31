using MediatR;

namespace Movies.Application.Commands.MovieRatings.DeleteMovieRating
{
    public class DeleteMovieRatingCommand : IRequest<int>
    {
        public int MovieRatingId { get; set; }
    }
}

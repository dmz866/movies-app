using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Queries.MovieRatings.GetMovieRating
{
    public class GetMovieRatingQuery : IRequest<MovieRating?>
    {
        public int MovieRatingId { get; set; }
    }
}

using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.MovieRatings.UpdateMovieRating
{
    public class UpdateMovieRatingCommand : IRequest<MovieRating>
    {
        public int MovieRatingId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

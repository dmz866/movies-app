using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.MovieRatings.CreateMovieRating
{
    public class CreateMovieRatingCommand : IRequest<MovieRating>
    {
        public int MovieRatingId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

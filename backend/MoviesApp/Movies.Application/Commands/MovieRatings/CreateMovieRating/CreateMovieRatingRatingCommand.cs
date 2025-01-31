using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.MovieRatings.CreateMovieRating
{
    public class CreateMovieRatingCommand : IRequest<MovieRating>
    {        
        public decimal Value { get; set; }

        public required int MovieId { get; set; }
    }
}

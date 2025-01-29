using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Queries.MovieRatings.GetMovieRatings
{
    public class GetMovieRatingsQuery : IRequest<IEnumerable<MovieRating>>
    {        
        public int MovieId { get; set; }
    }
}

using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Queries.MovieRatings.GetMovieRatings
{
    public class GetMovieRatingsQueryHandler : IRequestHandler<GetMovieRatingsQuery, IEnumerable<MovieRating>>
    {
        private readonly IMovieRatingService _movieratingService;

        public GetMovieRatingsQueryHandler(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

        public async Task<IEnumerable<MovieRating>> Handle(GetMovieRatingsQuery request, CancellationToken cancellationToken)
        {            
            var movieRatings = await _movieratingService.GetMovieRatings(request.MovieId);

            return movieRatings.Select(m => m.ToDomain());
        }
    }
}

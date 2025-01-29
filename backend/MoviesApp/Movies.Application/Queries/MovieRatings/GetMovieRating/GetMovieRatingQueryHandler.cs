using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Queries.MovieRatings.GetMovieRating
{
    public class GetMovieRatingHandler : IRequestHandler<GetMovieRatingQuery, MovieRating?>
    {
        private readonly IMovieRatingService _movieratingService;

        public GetMovieRatingHandler(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

        public async Task<MovieRating?> Handle(GetMovieRatingQuery request, CancellationToken cancellationToken)
        {
            var movierating = await _movieratingService.GetMovieRating(request.MovieRatingId);

            return movierating?.ToDomain();
        }
    }
}

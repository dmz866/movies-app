using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.MovieRatings.CreateMovieRating
{
    public class CreateMovieRatingCommandHandler : IRequestHandler<CreateMovieRatingCommand, MovieRating?>
    {
        private readonly IMovieRatingService _movieratingService;

        public CreateMovieRatingCommandHandler(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

        public async Task<MovieRating?> Handle(CreateMovieRatingCommand request, CancellationToken cancellationToken)
        {
            var movieRating = await _movieratingService.CreateMovieRating(request.ToModel());

            return movieRating?.ToDomain();
        }
    }
}

using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.MovieRatings.UpdateMovieRating
{
    public class UpdateMovieRatingHandler : IRequestHandler<UpdateMovieRatingCommand, MovieRating>
    {
        private readonly IMovieRatingService _movieratingService;

        public UpdateMovieRatingHandler(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

        public async Task<MovieRating> Handle(UpdateMovieRatingCommand request, CancellationToken cancellationToken)
        {
            var movierating = await _movieratingService.UpdateMovieRating(request.ToModel());

            return movierating.ToDomain();
        }
    }
}

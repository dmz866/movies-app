using MediatR;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.MovieRatings.DeleteMovieRating
{
    public class DeleteMovieRatingHandler : IRequestHandler<DeleteMovieRatingCommand>
    {
        private readonly IMovieRatingService _movieratingService;

        public DeleteMovieRatingHandler(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

        public async Task Handle(DeleteMovieRatingCommand request, CancellationToken cancellationToken)
        {
            await _movieratingService.DeleteMovieRating(request.MovieRatingId);
        }
    }
}

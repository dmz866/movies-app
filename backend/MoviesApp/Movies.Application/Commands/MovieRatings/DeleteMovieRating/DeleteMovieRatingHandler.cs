using MediatR;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.MovieRatings.DeleteMovieRating
{
    public class DeleteMovieRatingHandler : IRequestHandler<DeleteMovieRatingCommand, int>
    {
        private readonly IMovieRatingService _movieratingService;

        public DeleteMovieRatingHandler(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

        public async Task<int> Handle(DeleteMovieRatingCommand request, CancellationToken cancellationToken)
        {
            return await _movieratingService.DeleteMovieRating(request.MovieRatingId);
        }
    }
}

using MediatR;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Application.Commands.Movies.DeleteMovie
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieService _movieService;

        public DeleteMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            await _movieService.DeleteMovie(request.MovieId);
        }
    }
}

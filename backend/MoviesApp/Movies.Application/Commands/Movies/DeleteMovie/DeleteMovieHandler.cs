using MediatR;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Movies.DeleteMovie
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, int>
    {
        private readonly IMovieService _movieService;

        public DeleteMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<int> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.DeleteMovie(request.MovieId);
        }
    }
}

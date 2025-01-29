using MediatR;
using MoviesApp.Application.Entities;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Application.Commands.Movies.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
    {
        private readonly IMovieService _movieService;

        public CreateMovieCommandHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.CreateMovie(request.ToModel());

            return movie.ToDomain();
        }
    }
}

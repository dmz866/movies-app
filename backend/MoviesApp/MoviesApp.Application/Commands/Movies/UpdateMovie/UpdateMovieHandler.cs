using MediatR;
using MoviesApp.Application.Entities;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Application.Commands.Movies.UpdateMovie
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, Movie>
    {
        private readonly IMovieService _movieService;

        public UpdateMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.UpdateMovie(request.ToModel());

            return movie.ToDomain();
        }
    }
}

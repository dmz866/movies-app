using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Movies.UpdateMovie
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

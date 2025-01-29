using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Commands.Movies.CreateMovie
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

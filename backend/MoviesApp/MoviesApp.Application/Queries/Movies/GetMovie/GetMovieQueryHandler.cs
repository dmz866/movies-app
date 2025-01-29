using MediatR;
using MoviesApp.Application.Entities;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Application.Queries.Movies.GetMovie
{
    public class GetMovieHandler : IRequestHandler<GetMovieQuery, Movie?>
    {
        private readonly IMovieService _movieService;

        public GetMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<Movie?> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovie(request.MovieId);

            return movie?.ToDomain();
        }
    }
}

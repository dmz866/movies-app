using MediatR;
using MoviesApp.Application.Entities;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Application.Queries.Movies.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieService _movieService;

        public GetMoviesQueryHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {            
            var movies = await _movieService.GetMovies();

            return movies.Select(m => m.ToDomain());
        }
    }
}

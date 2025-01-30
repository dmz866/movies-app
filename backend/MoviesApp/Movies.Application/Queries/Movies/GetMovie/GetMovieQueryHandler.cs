using MediatR;
using Movies.Application.Entities;
using Movies.Services.Interfaces;

namespace Movies.Application.Queries.Movies.GetMovie
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
            var movieDomain = movie?.ToDomain();

            if (movieDomain != null && movie?.MovieRatings != null)
            {
                movieDomain.Rating = movie.MovieRatings.Sum(m => m.Value);
            }

            return movieDomain;
        }
    }
}

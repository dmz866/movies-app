using MoviesApp.Application.Commands.Movies.CreateMovie;
using MoviesApp.Application.Commands.Movies.UpdateMovie;

namespace MoviesApp.Application.Entities
{
    public static class MovieExtension
    {
        public static Movie ToDomain(this Services.Models.Movie movie)
        {
            return new Movie()
            {
                MovieId = movie.MovieId,
            };
        }

        public static Services.Models.Movie ToModel(this Movie movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
            };
        }


        public static Services.Models.Movie ToModel(this CreateMovieCommand movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
            };
        }

        public static Services.Models.Movie ToModel(this UpdateMovieCommand movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
            };
        }
    }
}

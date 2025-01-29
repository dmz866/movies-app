using Movies.Application.Commands.Movies.CreateMovie;
using Movies.Application.Commands.Movies.UpdateMovie;

namespace Movies.Application.Entities
{
    public static class MovieExtension
    {
        public static Movie ToDomain(this Services.Models.Movie movie)
        {
            return new Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
            };
        }

        public static Services.Models.Movie ToModel(this Movie movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
            };
        }


        public static Services.Models.Movie ToModel(this CreateMovieCommand movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
            };
        }

        public static Services.Models.Movie ToModel(this UpdateMovieCommand movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
            };
        }
    }
}

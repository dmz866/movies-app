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
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Actors = movie.Actors?.Select(a => a.ToDomain()).ToArray()
            };
        }

        public static Services.Models.Movie ToModel(this Movie movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Actors = (movie.Actors != null) ? (IEnumerable<Services.Models.Actor>)movie.Actors.ToList() : null,
                MovieRatings = (movie.MovieRatings != null) ? (IEnumerable<Services.Models.MovieRating>)movie.MovieRatings.ToList() : null
            };
        }

        public static Services.Models.Movie ToModel(this CreateMovieCommand movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Actors = movie.Actors?.Select(a => a.ToModel()),
                MovieRatings = movie.MovieRatings?.Select(a => a.ToModel()),
            };
        }

        public static Services.Models.Movie ToModel(this UpdateMovieCommand movie)
        {
            return new Services.Models.Movie()
            {
                MovieId = movie.MovieId,
                Name = movie.Name,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Actors = movie.Actors?.Select(a => a.ToModel()),
                MovieRatings = movie.MovieRatings?.Select(a => a.ToModel()),
            };
        }
    }
}

using Movies.Application.Commands.MovieRatings.CreateMovieRating;
using Movies.Application.Commands.MovieRatings.UpdateMovieRating;
using Movies.Services.Models;

namespace Movies.Application.Entities
{
    public static class MovieRatingExtension
    {
        public static MovieRating ToDomain(this Services.Models.MovieRating movieRating)
        {
            return new MovieRating()
            {
                MovieRatingId = movieRating.MovieRatingId,
                Name = movieRating.Name,
                Description = movieRating.Description,
                MovieId = movieRating.MovieId,
            };
        }

        public static Services.Models.MovieRating ToModel(this MovieRating movieRating)
        {
            return new Services.Models.MovieRating()
            {
                MovieRatingId = movieRating.MovieRatingId,
                Name = movieRating.Name,
                Description = movieRating.Description,
                MovieId = movieRating.MovieId,
            };
        }


        public static Services.Models.MovieRating ToModel(this CreateMovieRatingCommand movieRating)
        {
            return new Services.Models.MovieRating()
            {
                MovieRatingId = movieRating.MovieRatingId,
                Name = movieRating.Name,
                Description = movieRating.Description,
                MovieId = movieRating.MovieId,
            };
        }

        public static Services.Models.MovieRating ToModel(this UpdateMovieRatingCommand movieRating)
        {
            return new Services.Models.MovieRating()
            {
                MovieRatingId = movieRating.MovieRatingId,
                Name = movieRating.Name,
                Description = movieRating.Description,
                MovieId = movieRating.MovieId,
            };
        }
    }
}

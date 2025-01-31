namespace Movies.Services.Models
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }

        public decimal Value { get; set; }

        public required int MovieId { get; set; }

        public IEnumerable<Movie>? Movies { get; set; }
    }
}

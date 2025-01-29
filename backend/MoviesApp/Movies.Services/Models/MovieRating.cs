namespace Movies.Services.Models
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required int MovieId { get; set; }

        public IEnumerable<Movie>? Movies { get; set; }
    }
}

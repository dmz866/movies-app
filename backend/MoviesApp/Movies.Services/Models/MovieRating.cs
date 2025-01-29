namespace Movies.Services.Models
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required int MovieId { get; set; }

        public IEnumerable<Movie>? Movies { get; set; }

        public DateTimeOffset? Created { get; set; }

        public string? CreatedBy { get; set; } = string.Empty;

        public DateTimeOffset? Updated { get; set; }

        public string? UpdatedBy { get; set; } = string.Empty;
    }
}

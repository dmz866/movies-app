namespace Movies.Services.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }        

        public IEnumerable<Actor>? Actors { get; set; }

        public IEnumerable<MovieRating>? MovieRatings { get; set; }

        public DateTimeOffset? Created { get; set; }

        public string? CreatedBy { get; set; } = string.Empty;

        public DateTimeOffset? Updated { get; set; }

        public string? UpdatedBy { get; set; } = string.Empty;
    }
}

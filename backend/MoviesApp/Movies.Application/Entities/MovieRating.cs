namespace Movies.Application.Entities
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public int MovieId { get; set; }
    }
}

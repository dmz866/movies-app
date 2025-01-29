namespace Movies.Application.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }        
        
        public Actor[]? Actors { get; set; }

        public MovieRating[]? MovieRatings { get; set; }
    }
}

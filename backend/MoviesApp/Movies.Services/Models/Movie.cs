namespace Movies.Services.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public IEnumerable<MovieActor>? MovieActors { get; set; }

        public IEnumerable<Actor>? Actors { get; set; }

        public IEnumerable<MovieRating>? MovieRatings { get; set; }        
    }
}

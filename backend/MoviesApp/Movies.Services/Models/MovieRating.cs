namespace Movies.Services.Models
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MovieId { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}

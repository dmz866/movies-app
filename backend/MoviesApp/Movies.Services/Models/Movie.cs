namespace Movies.Services.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Actor> Actors { get; set; }
    }
}

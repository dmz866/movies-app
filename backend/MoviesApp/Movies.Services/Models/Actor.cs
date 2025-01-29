namespace Movies.Services.Models
{
    public class Actor
    {
        public int ActorId { get; set; }

        public required string Name { get; set; }

        public IEnumerable<Movie>? Movies { get; set; }
    }
}

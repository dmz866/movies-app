namespace Movies.Services.Models
{
    public class MovieActor
    {
        public int MovieActorId { get; set; }

        public required int MovieId { get; set; }

        public required int ActorId { get; set; }

        public required Movie Movie { get; set; }

        public required Actor Actor { get; set; }
    }
}

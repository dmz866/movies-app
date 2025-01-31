namespace Movies.Application.Entities
{
    public class MovieActor
    {
        public int MovieActorId { get; set; }

        public required int MovieId { get; set; }

        public required int ActorId { get; set; }
    }
}

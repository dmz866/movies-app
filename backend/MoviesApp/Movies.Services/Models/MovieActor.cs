namespace Movies.Services.Models
{
    public class MovieActor
    {
        public int MovieActorId { get; set; }

        public required int MovieId { get; set; }

        public required int ActorId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Actor Actor { get; set; }

        public DateTimeOffset? Created { get; set; }

        public string? CreatedBy { get; set; } = string.Empty;

        public DateTimeOffset? Updated { get; set; }

        public string? UpdatedBy { get; set; } = string.Empty;
    }
}

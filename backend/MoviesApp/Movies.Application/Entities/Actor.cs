namespace Movies.Application.Entities
{
    public class Actor
    {
        public int ActorId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public Movie[]? Movies { get; set; }
    }
}

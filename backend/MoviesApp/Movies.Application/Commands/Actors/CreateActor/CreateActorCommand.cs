using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Actors.CreateActor
{
    public class CreateActorCommand : IRequest<Actor?>
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int[]? MoviesIds { get; set; }
    }
}

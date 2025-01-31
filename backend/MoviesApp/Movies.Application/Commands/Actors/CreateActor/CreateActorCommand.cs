using System.ComponentModel.DataAnnotations;
using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Actors.CreateActor
{
    public class CreateActorCommand : IRequest<Actor?>
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int[]? MoviesIds { get; set; }
    }
}

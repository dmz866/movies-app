using System.ComponentModel.DataAnnotations;
using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Actors.UpdateActor
{
    public class UpdateActorCommand : IRequest<Actor>
    {
        public int ActorId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}

using Movies.Application.Commands.Actors.CreateActor;
using Movies.Application.Commands.Actors.UpdateActor;

namespace Movies.Application.Entities
{
    public static class ActorExtension
    {
        public static Actor ToDomain(this Services.Models.Actor actor)
        {
            return new Actor()
            {
                ActorId = actor.ActorId,
                Name = actor.Name,
            };
        }

        public static Services.Models.Actor ToModel(this Actor actor)
        {
            return new Services.Models.Actor()
            {
                ActorId = actor.ActorId,
                Name = actor.Name,
            };
        }


        public static Services.Models.Actor ToModel(this CreateActorCommand actor)
        {
            return new Services.Models.Actor()
            {
                ActorId = actor.ActorId,
                Name = actor.Name,
            };
        }

        public static Services.Models.Actor ToModel(this UpdateActorCommand actor)
        {
            return new Services.Models.Actor()
            {
                ActorId = actor.ActorId,
                Name = actor.Name,
            };
        }
    }
}

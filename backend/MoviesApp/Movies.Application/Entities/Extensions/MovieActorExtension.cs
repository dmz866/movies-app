namespace Movies.Application.Entities
{
    public static class MovieActorExtension
    {
        public static MovieActor ToDomain(this Services.Models.MovieActor movieActor)
        {
            return new MovieActor()
            {
                MovieActorId = movieActor.MovieActorId,
                ActorId = movieActor.ActorId,
                MovieId = movieActor.MovieId,
            };
        }

        public static Services.Models.MovieActor ToModel(this MovieActor movieActor)
        {
            return new Services.Models.MovieActor()
            {
                MovieActorId = movieActor.MovieActorId,
                ActorId = movieActor.ActorId,
                MovieId = movieActor.MovieId,
            };
        }
    }
}

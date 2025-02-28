﻿namespace Movies.Services.Models
{
    public class MovieActor
    {
        public int MovieActorId { get; set; }

        public required int MovieId { get; set; }

        public required int ActorId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Actor Actor { get; set; }
    }
}

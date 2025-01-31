﻿using MediatR;
using Movies.Application.Entities;

namespace Movies.Application.Commands.Movies.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}

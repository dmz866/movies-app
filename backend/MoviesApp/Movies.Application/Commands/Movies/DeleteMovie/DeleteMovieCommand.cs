using MediatR;

namespace Movies.Application.Commands.Movies.DeleteMovie
{
    public class DeleteMovieCommand : IRequest
    {
        public int MovieId { get; set; }
    }
}

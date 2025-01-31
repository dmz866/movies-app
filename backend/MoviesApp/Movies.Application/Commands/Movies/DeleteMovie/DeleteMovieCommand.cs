using MediatR;

namespace Movies.Application.Commands.Movies.DeleteMovie
{
    public class DeleteMovieCommand : IRequest<int>
    {
        public int MovieId { get; set; }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands.Movies.CreateMovie;
using Movies.Application.Commands.Movies.DeleteMovie;
using Movies.Application.Commands.Movies.UpdateMovie;
using Movies.Application.Queries.Movies.GetMovie;
using Movies.Application.Queries.Movies.GetMovies;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : BaseController
    {
        public MoviesController(IMediator mediator, ILogger<MoviesController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovie(int movieId)
        {
            var request = new GetMovieQuery() { MovieId = movieId };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("search-by/{name}")]
        public async Task<IActionResult> GetMovies(string? name)
        {
            var request = new GetMoviesQuery() { Name = name };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            var request = new DeleteMovieCommand() { MovieId = movieId };
            await _mediator.Send(request);

            return Ok();
        }
    }
}

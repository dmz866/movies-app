using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Queries.Movies.GetMovies;

namespace MoviesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : BaseController
    {
        public MoviesController(IMediator mediator, ILogger<MoviesController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var request = new GetMoviesQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}

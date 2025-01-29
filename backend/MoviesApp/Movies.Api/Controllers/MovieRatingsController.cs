using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Controllers;
using Movies.Application.Commands.MovieRatings.CreateMovieRating;
using Movies.Application.Commands.MovieRatings.DeleteMovieRating;
using Movies.Application.Commands.MovieRatings.UpdateMovieRating;
using Movies.Application.Queries.MovieRatings.GetMovieRatings;

namespace MovieRatings.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieRatingsController : BaseController
    {
        public MovieRatingsController(IMediator mediator, ILogger<MovieRatingsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("{movieRatingId}")]
        public async Task<IActionResult> GetMovieRating(int movieratingId)
        {
            var request = new GetMovieRatingsQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetMovieRatings(int movieId)
        {
            var request = new GetMovieRatingsQuery() { MovieId = movieId };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieRating([FromBody] CreateMovieRatingCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovieRating([FromBody] UpdateMovieRatingCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{movieRatingId}")]
        public async Task<IActionResult> DeleteMovieRating(int movieratingId)
        {
            var request = new DeleteMovieRatingCommand() { MovieRatingId = movieratingId };
            await _mediator.Send(request);

            return Ok();
        }
    }
}

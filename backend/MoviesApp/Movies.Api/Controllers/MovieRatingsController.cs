using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Controllers;
using Movies.Application.Commands.MovieRatings.CreateMovieRating;
using Movies.Application.Commands.MovieRatings.DeleteMovieRating;
using Movies.Application.Commands.MovieRatings.UpdateMovieRating;
using Movies.Application.Queries.MovieRatings.GetMovieRating;
using Movies.Application.Queries.MovieRatings.GetMovieRatings;

namespace MovieRatings.Api.Controllers
{
    /// <summary>
    /// Movie Ratings Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieRatingsController : BaseController
    {
        public MovieRatingsController(IMediator mediator, ILogger<MovieRatingsController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Get a single Movie Rating record
        /// </summary>
        /// <param name="movieRatingId"></param>
        /// <returns>an MovieRating record</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /MovieRatings/movieRatingId
        ///    
        ///
        /// </remarks>
        /// <response code="200">Returns an Movie Rating record</response>
        /// <response code="404">No content if Movie Rating record not found</response>
        [HttpGet("{movieRatingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieRating(int movieRatingId)
        {
            var request = new GetMovieRatingQuery() { MovieRatingId = movieRatingId };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get a list of Movie Rating records
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>List of Movie Rating records</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /MovieRatings/movie/movieId
        ///    
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Movie Rating records</response>
        /// <response code="404">No content if Movie Rating records not found</response>
        [HttpGet("movie/{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieRatings(int movieId)
        {
            var request = new GetMovieRatingsQuery() { MovieId = movieId };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Creates an Movie Rating record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A new created Movie Rating</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /MovieRatings
        ///     {
        ///        "Value": "8.8",
        ///        "MovieId": "1",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a new created Movie Rating</response>
        /// <response code="400">If the request is invalid and the new Movie Rating record is null</response>
        [HttpPost]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMovieRating([FromBody] CreateMovieRatingCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Update an existing Movie Rating record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>An existing Movie Rating record</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /MovieRatings
        ///     {
        ///        "MovieRatingId: "1",
        ///        "Value": "8.8",
        ///        "MovieId": "1",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated Movie Rating record</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPut]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMovieRating([FromBody] UpdateMovieRatingCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Delete an existing Movie Rating record
        /// </summary>
        /// <param name="movieRatingId"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /MovieRatings/movieRatingId        
        ///
        /// </remarks>
        /// <response code="200">If Movie Rating record deleted successfully</response>
        /// <response code="400">If the Movie Rating record does not exist</response>
        [HttpDelete("{movieRatingId}")]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieRating(int movieRatingId)
        {
            var request = new DeleteMovieRatingCommand() { MovieRatingId = movieRatingId };
            await _mediator.Send(request);

            return Ok();
        }
    }
}

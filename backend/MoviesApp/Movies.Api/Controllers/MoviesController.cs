using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands.Movies.CreateMovie;
using Movies.Application.Commands.Movies.DeleteMovie;
using Movies.Application.Commands.Movies.UpdateMovie;
using Movies.Application.Queries.Movies.GetMovie;
using Movies.Application.Queries.Movies.GetMovies;

namespace Movies.Api.Controllers
{
    /// <summary>
    /// Movies Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : BaseController
    {
        public MoviesController(IMediator mediator, ILogger<MoviesController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Get a single Movie record
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>an Movie record</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Movies/movieId
        ///    
        ///
        /// </remarks>
        /// <response code="200">Returns an Movie record</response>
        /// <response code="404">No content if Movie record not found</response>
        [HttpGet("{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovie(int movieId)
        {
            var request = new GetMovieQuery() { MovieId = movieId };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get a list of Movie records
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Movie records</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Movies/search-by/name
        ///    
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Movie records</response>
        /// <response code="404">No content if Movie records not found</response>
        [HttpGet("search-by/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovies(string? name)
        {
            var request = new GetMoviesQuery() { Name = name };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Creates an Movie record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A new created Movie</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Movies
        ///     {
        ///        "Name": "Name Test",
        ///        "Description": "Description Test",
        ///        "ImageUrl": "Image Url Test"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a new created Movie</response>
        /// <response code="400">If the request is invalid and the new Movie record is null</response>
        [HttpPost]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Update an existing Movie record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>An existing Movie record</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Movies
        ///     {
        ///        "MovieId: "1",
        ///        "Name": "Name Test",
        ///        "Description": "Description Test",
        ///        "ImageUrl": "Image Url Test"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated Movie record</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPut]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Delete an existing Movie record
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Movies/movieId        
        ///
        /// </remarks>
        /// <response code="200">If Movie record deleted successfully</response>
        /// <response code="400">If the Movie record does not exist</response>
        [HttpDelete("{movieId}")]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            var request = new DeleteMovieCommand() { MovieId = movieId };
            await _mediator.Send(request);

            return Ok();
        }
    }
}

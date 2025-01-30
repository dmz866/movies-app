using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Controllers;
using Movies.Application.Commands.Actors.CreateActor;
using Movies.Application.Commands.Actors.DeleteActor;
using Movies.Application.Commands.Actors.UpdateActor;
using Movies.Application.Queries.Actors.GetActor;
using Movies.Application.Queries.Actors.GetActors;

namespace Actors.Api.Controllers
{
    /// <summary>
    /// Actors Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ActorsController : BaseController
    {
        public ActorsController(IMediator mediator, ILogger<ActorsController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Get a single Actor record
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns>an Actor record</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Actors/actorId
        ///    
        ///
        /// </remarks>
        /// <response code="200">Returns an Actor record</response>
        /// <response code="404">No content if Actor record not found</response>
        [HttpGet("{actorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActor(int actorId)
        {
            var request = new GetActorQuery() { ActorId = actorId };
            var result = await _mediator.Send(request);

            return (result != null) ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Get a list of Actor records
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of Actor records</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Actors/search-by/name
        ///    
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Actor records</response>
        /// <response code="404">No content if Actor records not found</response>
        [HttpGet("search-by/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActors(string? name)
        {
            var request = new GetActorsQuery() { Name = name };
            var result = await _mediator.Send(request);

            return (result != null && result.Any()) ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates an Actor record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A new created Actor</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Actors
        ///     {
        ///        "Name": "Name Test",
        ///        "Description": "Description Test",
        ///        "ImageUrl": "Image Url Test"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a new created Actor</response>
        /// <response code="400">If the request is invalid and the new Actor record is null</response>
        [HttpPost]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateActor([FromBody] CreateActorCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Update an existing Actor record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>An existing Actor record</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Actors
        ///     {
        ///        "ActorId: "1",
        ///        "Name": "Name Test",
        ///        "Description": "Description Test",
        ///        "ImageUrl": "Image Url Test"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated Actor record</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPut]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateActor([FromBody] UpdateActorCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Delete an existing Actor record
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Actors/actorId        
        ///
        /// </remarks>
        /// <response code="200">If Actor record deleted successfully</response>
        /// <response code="404">If the Actor record does not exist</response>
        [HttpDelete("{actorId}")]
        [Authorize("ApiKeyOrBearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActor(int actorId)
        {
            var request = new DeleteActorCommand() { ActorId = actorId };
            var result = await _mediator.Send(request);

            return (result > 0) ? Ok(result) : NotFound();
        }
    }
}

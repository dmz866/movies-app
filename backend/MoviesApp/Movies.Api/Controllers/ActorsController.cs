using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Controllers;
using Movies.Application.Commands.Actors.CreateActor;
using Movies.Application.Commands.Actors.DeleteActor;
using Movies.Application.Commands.Actors.UpdateActor;
using Movies.Application.Queries.Actors.GetActors;

namespace Actors.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorsController : BaseController
    {
        public ActorsController(IMediator mediator, ILogger<ActorsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("{actorId}")]
        public async Task<IActionResult> GetActor(int actorId)
        {
            var request = new GetActorsQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetActors(string? name)
        {
            var request = new GetActorsQuery() { Name = name };
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] CreateActorCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor([FromBody] UpdateActorCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{actorId}")]
        public async Task<IActionResult> DeleteActor(int actorId)
        {
            var request = new DeleteActorCommand() { ActorId = actorId };
            await _mediator.Send(request);

            return Ok();
        }
    }
}

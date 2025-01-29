using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _mediator { get; private set; }

        protected ILogger<BaseController> _logger;

        internal BaseController(IMediator mediator, ILogger<BaseController> logger)
        {
            if (mediator == null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            _mediator = mediator;

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger;
        }
    }
}

using Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier notifier;
        protected IMediator mediator;

        protected MainController(INotifier notifier, IMediator mediator)
        {
            this.notifier = notifier;
            this.mediator = mediator;
        }

        protected ActionResult CustomResponse(object? response)
        {
            var errors = notifier.GetNotifications().Select(n => n.Message);

            if (errors.Any()) return BadRequest(ApiResponses.CreateKO(response, errors));

            return Ok(ApiResponses.Ok(response));
        }
    }
}

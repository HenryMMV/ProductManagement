using Application.Services.Users.Commands.Login;
using Application.Services.Users.Commands.SignUp;
using Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthController : MainController
    {
        public AuthController(INotifier notifier, IMediator mediator) : base(notifier, mediator)
        {
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            var response = await mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await mediator.Send(request);
            return CustomResponse(response);
        }
    }
}

using MediatR;

namespace Application.Services.Users.Commands.SignUp
{
    public class SignUpRequest : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

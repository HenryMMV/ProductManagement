using Domain.Models.Entities;
using Domain.Notifications;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Users.Commands.SignUp
{
    public class SignUpRequestHandler : RequestHandlerBase<SignUpRequest, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SignUpRequestHandler(INotifier notifier, UserManager<ApplicationUser> userManager) : base(notifier)
        {
            _userManager = userManager;
        }

        public override async Task<bool> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            var identityUser = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var response = await _userManager.CreateAsync(identityUser, request.Password);
            return true;
        }
    }
}

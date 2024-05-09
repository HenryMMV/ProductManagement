using Domain.Models.Configurations;
using Domain.Models.Entities;
using Domain.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services.Users.Commands.Login
{
    public class LoginRequestHandler : RequestHandlerBase<LoginRequest, LoginResponse?>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtConfig _config;
        public LoginRequestHandler(INotifier notifier, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtConfig> config) : base(notifier)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config.Value;
        }

        public override async Task<LoginResponse?> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByEmailAsync(request.Email);
            if (identityUser == null)
            {
                Notify("Datos inválidos.");
                return null;
            }
            var response = await _signInManager.PasswordSignInAsync(user: identityUser, password: request.Password, isPersistent: true, lockoutOnFailure: false);
            if(!response.Succeeded)
            {
                Notify("Datos inválidos.");
                return null;
            }

            var accessToken = GenerateToken(identityUser);
            return new LoginResponse
            {
                Email = request.Email,
                AccessToken = accessToken,
            };
        }

        private string GenerateToken(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                claims: GenerateClaims(user),
                expires: DateTime.UtcNow.AddMinutes(_config.ExpirationMinutes),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> GenerateClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Expiration, TimeSpan.FromMinutes(_config.ExpirationMinutes).Ticks.ToString()),
                new(ClaimTypes.Email, user.Email)
            };
            return claims;
        }
    }
}

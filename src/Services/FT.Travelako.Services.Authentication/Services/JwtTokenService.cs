using FT.Travelako.Services.Authentication.Configuration;
using Microsoft.AspNetCore.Authentication;
using FT.Travelako.Services.Authentication.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace FT.Travelako.Services.Authentication.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private IAppSettingsConfiguration _config;
        private ILogger<JwtTokenService> _logger;
        public JwtTokenService(IAppSettingsConfiguration config, ILogger<JwtTokenService> logger)
        {
            _config = config;
            _logger = logger;

        }
        private readonly List<User> _users = new()
    {
        new("admin", "aDm1n", UserRoles.Administrator),
        new("user01", "u$3r01", UserRoles.User),
        new("buser01", "bu$3r01", UserRoles.Business)
    };
        public AuthenticationToken? GenerateAuthToken(LoginModel loginModel)
        {
            var user = _users.FirstOrDefault(u => u.UserName == loginModel.UserName
                                               && u.Password == loginModel.Password);
            if (user is null)
            {
                return null;
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey.ToString()));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("roles", user.Role.ToString().ToLower())
            };
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5002",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthenticationToken()
            {
                Name = tokenString,
                Value = ((int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds).ToString()
            };
        }
    }
}

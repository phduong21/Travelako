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
        public AuthenRespone? GenerateAuthToken(LoginModel user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey.ToString()));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(60);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("id", user.Id),
                new Claim("roles", user.Role.ToString().ToLower())
            };
            var tokenOptions = new JwtSecurityToken(
                issuer: "",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthenRespone()
            {
                Token = tokenString
            };
        }
    }
}

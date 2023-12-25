using FT.Travelako.OcelotApiGw.Configuration;
using FT.Travelako.OcelotApiGw.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FT.Travelako.OcelotApiGw.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        private AppSettingsConfiguration _config;
        private ILogger<JwtTokenService> _logger;
        public JwtTokenService(IOptionsMonitor<AppSettingsConfiguration> configration, ILogger<JwtTokenService> logger)
        {
            _config = configration.CurrentValue;
            _logger = logger;

        }
        private readonly List<User> _users = new()
    {
        new("admin", "aDm1n", UserRoles.Administrator,new[] {"coupon.all"}),
        new("user01", "u$3r01", UserRoles.User,new[] {"coupon.read"}),
        new("buser01", "bu$3r01", UserRoles.Business,new[] {"shoes.write"})
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
                new Claim("role", user.Role.ToString().ToLower()),
                new Claim("scope", string.Join(" ", user.Scope))
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

            //var jwtTokenHandler = new JwtSecurityTokenHandler();
            //var secretKeyBytes = Encoding.UTF8.GetBytes(_config.SecretKey.ToString());
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Claims = new Dictionary<string, object>() {
            //    {ClaimTypes.Role,user.Role.ToString().ToLower()}
            //    },
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim("role", user.Role.ToString().ToLower()),
            //        //new Claim(ClaimTypes.Name, user.UserName),
            //        //new Claim("UserName", user.UserName),
            //        //new Claim("Id", user.UserName.ToString()),
            //        ////Todo
            //        ////roles

            //        //new Claim("TokenId", Guid.NewGuid().ToString())

            //    }),

            //    Expires = DateTime.UtcNow.AddMinutes(5),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature),
            //};

            //var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            //return jwtTokenHandler.WriteToken(token);
        }
    }
}

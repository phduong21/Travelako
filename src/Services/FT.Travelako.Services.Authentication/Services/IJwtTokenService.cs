using FT.Travelako.Services.Authentication.Model;
using Microsoft.AspNetCore.Authentication;

namespace FT.Travelako.Services.Authentication.Services
{
    public interface IJwtTokenService
    {
        public AuthenticationToken? GenerateAuthToken(LoginModel loginModel);
    }
}

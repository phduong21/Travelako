using FT.Travelako.OcelotApiGw.Models;
using Microsoft.AspNetCore.Authentication;

namespace FT.Travelako.OcelotApiGw.Service
{
    public interface IJwtTokenService
    {
        public AuthenticationToken? GenerateAuthToken(LoginModel loginModel);
    }
}

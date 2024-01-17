using FT.Travelako.UI.Models.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace FT.Travelako.UI.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationToken> LoginUser(LoginModel model);
    }
}

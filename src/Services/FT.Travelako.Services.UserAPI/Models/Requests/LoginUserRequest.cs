using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.Requests
{
    public class LoginUserRequest : IBaseRequestModel
    {
        public LoginUserRequest() { }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

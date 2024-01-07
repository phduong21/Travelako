using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.Authentication.Data;
using FT.Travelako.Services.Authentication.Model.Request_Model;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.Authentication.Services.Mediator_Service
{
    public class LoginService : BaseExecutionService<LoginUserRequest>
    {
        private AppDbContext _context;
        private IJwtTokenService _authen;
        public LoginService(AppDbContext context, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _authen = jwtTokenService;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(LoginUserRequest model)
        {
            var result = new GenericAPIResponse
            {
                IsSuccess = false,
                Message = string.Empty,
            };
            //logic here here
            if (string.IsNullOrEmpty(model.UserName))
            {
                result.Message = $"User name :{model.UserName} is invalid";
                return result;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                result.Message = $"Password is invalid";
                return result;
            }

            //Need update if password is hash
            var user = await _context.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).SingleOrDefaultAsync();
            if (user == null)
            {
                result.Message = $"User name or Password is invalid";
                return result;
            }

            result.IsSuccess = true;
            result.Data = _authen.GenerateAuthToken(new Model.LoginModel() { UserName = user.UserName, Role = user.Role });

            //call to repo here
            return result;
        }
    }
}

using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.Authentication.Data;
using FT.Travelako.Services.Authentication.Extensions;
using FT.Travelako.Services.Authentication.Model.Request_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace FT.Travelako.Services.Authentication.Services.Mediator_Service
{
    public class LoginService : BaseExecutionService<LoginUserRequest>
    {
        private AppDbContext _context;
        private IJwtTokenService _authen;
        private IDistributedCache _cache;
        public LoginService(AppDbContext context, IJwtTokenService jwtTokenService,IDistributedCache cache)
        {
            _context = context;
            _authen = jwtTokenService;
            _cache = cache;
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
            try
            {
                var user = await _context.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).SingleOrDefaultAsync();
                //if (user == null)
                //{
                //    result.Message = $"User name or Password is invalid";
                //    return result;
                //}
                result.IsSuccess = true;
                //var tokenData = _authen.GenerateAuthToken(new Model.LoginModel() { UserName = user.UserName, Role = user.Role, Id = user.Id.ToString() });
                var id = Guid.NewGuid().ToString();
                var tokenData = _authen.GenerateAuthToken(new Model.LoginModel() { UserName = model.UserName, Role = "Administrator", Id = id });
                result.Data = tokenData;
                //await _cache.RemoveAsync($"user-{user.Id}");
                //await _cache.SetRecordAsync($"user-{user.Id}", tokenData.Name);
                await _cache.RemoveAsync($"user-{id}");
                await _cache.SetRecordAsync($"user-{id}", tokenData.Name);
            }
            catch (Exception ex)
            {
                return result;
            }
            

            return result;
        }
    }
}

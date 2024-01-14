using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models.Requests;
using AutoMapper;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class LoginService : BaseExecutionService<LoginUserRequest>
    {
        private UserAppDbContext _context;
        public LoginService(UserAppDbContext context) 
        {
            _context = context;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(LoginUserRequest model)
        {
            var result =  new GenericAPIResponse
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


            //call to repo here
            return new GenericAPIResponse
            {
                IsSuccess = true,
                Message = "123456789a-user",
            };
        }
    }
}

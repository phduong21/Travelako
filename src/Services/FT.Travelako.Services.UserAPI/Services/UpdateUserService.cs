using AutoMapper;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class UpdateUserService : BaseExecutionService<UpdateUserRequest>
    {
        private readonly IMapper _mapper;
        public UpdateUserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(UpdateUserRequest model)
        {
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };
            if (model.Id is null)
            {
                result.Message = "Id cannot be null";
                return result;
            }

            var context = new UserAppDbContext();
            var user = await context.Users
                .Include(r => r.Role)
                .Where(x => x.Id.ToString().ToLower() == model.Id)
                .SingleOrDefaultAsync();

            if (user == null)
            {

            }

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.Image = model.Image;

            context.Users.Attach(user);
            await context.SaveChangesAsync();

            var updatedUser = await context.Users
                .Include(r => r.Role)
                .Where(x => x.Id.ToString().ToLower() == model.Id)
                .SingleOrDefaultAsync();
            var data = _mapper.Map<UserDTO>(updatedUser);

            return new GenericAPIResponse
            {
                IsSuccess = true,
                Result = data
            };
        }

    }
}

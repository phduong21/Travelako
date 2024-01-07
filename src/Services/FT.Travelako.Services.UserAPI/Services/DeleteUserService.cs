using AutoMapper;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class DeleteUserService : BaseExecutionService<DeleteUserRequest>
    {
        private readonly IMapper _mapper;
        public DeleteUserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(DeleteUserRequest model)
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
                .Where(x => x.Id.ToString().ToLower() == model.Id.ToString())
                .SingleOrDefaultAsync();

            if (user is not null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            

            return new GenericAPIResponse();
        }

    }

}

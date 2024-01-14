using AutoMapper;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class DeleteUserService : UserBaseService<DeleteUserRequest>
    {
        public DeleteUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {

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

            var user = await _userRepository.GetByIdAsync(model.Id);

            if (user is not null)
            {
                await _userRepository.DeleteAsync(user);
            }


            return new GenericAPIResponse();
        }

    }

}

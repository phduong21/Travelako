using AutoMapper;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Data;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class UpdateUserService : UserBaseService<UpdateUserRequest>
    {
        private readonly IMapper _mapper;

        public UpdateUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
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

            var currentUser = await _userRepository.GetByIdAsync(model.Id);

            if (currentUser == null)
            {

            }
            var userToUpdate = _mapper.Map(model, currentUser);
            userToUpdate.LastModifiedDate = DateTime.Now;
            var updatedUser = await _userRepository.UpdateUserInformationAsync(userToUpdate);
            if (updatedUser is null)
            {

            }
            UserDTO data = _mapper.Map<UserDTO>(updatedUser);

            return new GenericAPIResponse
            {
                IsSuccess = true,
                Result = data
            };
        }

    }
}

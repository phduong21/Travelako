﻿using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Constants;
using FT.Travelako.Services.UserAPI.Extensions;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class DeleteUserService : UserBaseService<DeleteUserRequest>
    {
        public DeleteUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {

        }

        public override async Task<GenericAPIResponse> ExecuteApi(DeleteUserRequest model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    return ResponseExtension.ErrorResponse(string.Format(UserConstants.ErrorMessage.NullError, $"{nameof(model.Id)}"));
                }

                var currentUser = await _userRepository.GetByIdAsync(model.Id);
                if (currentUser == null)
                {
                    return ResponseExtension.ErrorResponse(UserConstants.ErrorMessage.UserNotFound);
                }
                currentUser.IsDeleted = true;
                currentUser.LastModifiedDate = DateTime.Now;
                await _userRepository.DeleteUser(currentUser);

                return new GenericAPIResponse()
                {
                    Message = UserConstants.DeleteSuccesfully
                };
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
        }
    }
}

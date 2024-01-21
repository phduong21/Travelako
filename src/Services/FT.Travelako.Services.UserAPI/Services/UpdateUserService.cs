using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Helpers;
using FT.Travelako.Services.UserAPI.Constants;
using FT.Travelako.Services.UserAPI.Extensions;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

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
            try
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    return ResponseExtension.ErrorResponse(string.Format(UserConstants.ErrorMessage.NullError, $"{nameof(model.Id)}"));
                }
                if (!string.IsNullOrWhiteSpace(model.Email) && !StringHelper.IsEmail(model.Email))
                {
                    return ResponseExtension.ErrorResponse(UserConstants.ErrorMessage.WrongEmailFormat);
                }
                
                var currentUser = await _userRepository.GetByIdAsync(model.Id);
                if (currentUser == null)
                {
                    return ResponseExtension.ErrorResponse(UserConstants.ErrorMessage.UserNotFound);
                }
                if (currentUser.Email !=  null && currentUser.Email != model.Email) 
                {
                    if (await _userRepository.IsEmailAlreadyExistsAsync(model.Email))
                    {
                        return ResponseExtension.ErrorResponse(string.Format(UserConstants.ErrorMessage.DataExisted, $"{model.Email}"));
                    }
                }
                
                var userToUpdate = _mapper.Map(model, currentUser);
                userToUpdate.LastModifiedDate = DateTime.Now;
                var updatedUser = await _userRepository.UpdateUserInformationAsync(userToUpdate);

                return ResponseExtension.SuccessResponse(_mapper.Map<UserDTO>(updatedUser));
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
        }
    }
}

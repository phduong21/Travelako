using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;
using FT.Travelako.Common.Helpers;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Constants;
using FT.Travelako.Services.UserAPI.Extensions;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class CreateUserService : UserBaseService<CreateUserRequest>
    {
        private readonly IMapper _mapper;
        public CreateUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }
        public override async Task<GenericAPIResponse> ExecuteApi(CreateUserRequest model)
        {
            try
            {
                if (!StringHelper.IsEmail(model.Email))
                {
                    return ResponseExtension.ErrorResponse(UserConstants.ErrorMessage.WrongEmailFormat);
                }

                if (await _userRepository.IsUserNameOrEmailAlreadyExists(model.UserName, model.Email))
                {
                    return ResponseExtension.ErrorResponse(string.Format(UserConstants.ErrorMessage.DataExisted, $"{model.Email} or {model.UserName}"));
                }
                // TODO: verify password requirement

                User userToCreate = _mapper.Map<User>(model);
                userToCreate.Password = PasswordHelper.HashPassword(model.Password);
                userToCreate.CreatedDate = DateTime.Now;
                var createdUser = await _userRepository.AddAsync(userToCreate);
                var userDto = _mapper.Map<UserDTO>(createdUser);
                
                return ResponseExtension.SuccessResponse(_mapper.Map<UserDTO>(createdUser));
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
       
        }

        private async Task VerifyRegisterpassword(string password)
        {

        }
    }

}

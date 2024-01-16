using AutoMapper;
using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;
using System.Reflection.Metadata.Ecma335;
using FT.Travelako.Common.Helpers;
using System.Text.RegularExpressions;
using FT.Travelako.Services.UserAPI.Models;

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
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };

            if (!StringHelper.IsEmail(model.Email))
            {
                return result;
            }
            if (await _userRepository.IsUserNameOrEmailAlreadyExists(model.UserName, model.Email))
            {
                return result;
            }
            // TODO: verify password requirement

            User userToCreate = _mapper.Map<User>(model);
            userToCreate.Password = PasswordHelper.HashPassword(model.Password);
            userToCreate.CreatedDate = DateTime.Now;
            var createdUser = await _userRepository.AddAsync(userToCreate);
            
            var userDto = _mapper.Map<UserDTO>(createdUser);
            return new GenericAPIResponse
            {
                IsSuccess = true,
                Result = userDto
            };
        }

        private async Task VerifyRegisterpassword(string password)
        {

        }
    }

}

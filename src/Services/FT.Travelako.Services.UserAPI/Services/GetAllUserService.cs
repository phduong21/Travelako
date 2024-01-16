using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class GetAllUserService : UserBaseService<GetAllUserRequest>
    {
        private readonly IMapper _mapper;
        public GetAllUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(GetAllUserRequest model)
        {
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };

            var user = await _userRepository.GetAllAsync();

            if (user == null)
            {

            }
            // UserDTO data = _mapper.Map<UserDTO>(user);

            return new GenericAPIResponse
            {
                IsSuccess = true,
                Result = user
            };
        }
    }
}

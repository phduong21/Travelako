using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Models;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class GetBusinessUserService : UserBaseService<DefaultRequest>
    {
        private readonly IMapper _mapper;
        public GetBusinessUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }

        public override async Task<GenericAPIResponse> ExecuteApi(DefaultRequest model)
        {
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };

            var users = await _userRepository.GetAllAsync();

            if (users == null)
            {

            }
            var businessUser = users.Where(x => x.Role == UserRoles.Business.ToString()).ToList();
            // UserDTO data = _mapper.Map<UserDTO>(user);

            return new GenericAPIResponse
            {
                IsSuccess = true,
                Result = businessUser
            };
        }
    }
}

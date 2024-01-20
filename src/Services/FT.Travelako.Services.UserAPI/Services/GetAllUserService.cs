using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Extensions;
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
            try
            {
                var activeUsers = await _userRepository.GetAllAsync();

                return ResponseExtension.SuccessResponse(_mapper.Map<List<UserDTO>>(activeUsers));
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
        }
    }
}

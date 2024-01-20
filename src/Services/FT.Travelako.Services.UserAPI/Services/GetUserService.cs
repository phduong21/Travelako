using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Constants;
using FT.Travelako.Services.UserAPI.Extensions;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class GetUserService : UserBaseService<GetUserRequest>
    {
        private readonly IMapper _mapper;

        public GetUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }


        public override async Task<GenericAPIResponse> ExecuteApi(GetUserRequest model)
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

                return ResponseExtension.SuccessResponse(_mapper.Map<UserDTO>(currentUser));
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
        }
    }
}

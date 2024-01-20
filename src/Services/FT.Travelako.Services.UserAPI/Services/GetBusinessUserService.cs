using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Models;
using FT.Travelako.Services.UserAPI.Extensions;
using FT.Travelako.Services.UserAPI.Models.DTOs;
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
            try
            {
                var users = await _userRepository.GetAllAsync();
                if (users is not null)
                {
                    var businessUser = users.Where(x => x.Role == UserRoles.Business.ToString()).ToList();

                    return new GenericAPIResponse
                    {
                        Result = _mapper.Map<List<UserDTO>>(businessUser)
                    };
                }

                return new GenericAPIResponse()
                {
                    Result = new UserDTO()
                };
            }
            catch (Exception ex)
            {
                return ResponseExtension.ErrorResponse(ex.Message);
            }
        }
    }
}

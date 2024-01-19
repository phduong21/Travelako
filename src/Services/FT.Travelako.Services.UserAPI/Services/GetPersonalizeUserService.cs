using AutoMapper;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;
using FT.Travelako.Services.UserAPI.Repositories;
using FT.Travelako.Services.UserAPI.Services.Base;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class GetPersonalizeUserService : UserBaseService<GetPersonalizeRequest>
    {
        private readonly IMapper _mapper;

        public GetPersonalizeUserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _mapper = mapper;
        }


        public override async Task<GenericAPIResponse> ExecuteApi(GetPersonalizeRequest model)
        {
            var result = new GenericAPIResponse()
            {
                IsSuccess = false
            };
            if(model.Id is null)
            {
                result.Message = "Id cannot be null";
                return result;
            }

            var user = await _userRepository.GetByIdAsync(model.Id);

            if (user == null)
            {

            }
            var data = _mapper.Map<PersonalizeDTO>(user);

            return  new GenericAPIResponse
            {
                IsSuccess = true,
                Result = data
            };
        }
         
    }
}

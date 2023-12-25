using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class GetUserService : BaseExecutionService<GetUserRequestDTO>
    {
        public GetUserService() { }

        public override async Task<GenericAPIResponse> ExecuteApi(GetUserRequestDTO model)
        {
            //logic here here
            //call to repo here
            return  new GenericAPIResponse
            {
                IsSuccess = true,
                Message = "123456789a-user",
            };
        }

    }
}

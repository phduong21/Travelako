using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.Requests;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class UpdateUserService : BaseExecutionService<UpdateUserRequest>
    {
        public UpdateUserService() { }

        public override async Task<GenericAPIResponse> ExecuteApi(UpdateUserRequest model)
        {
            //logic here here
            //call to repo here
            return new GenericAPIResponse
            {
                IsSuccess = true,
                Message = "123456789a-user",
            };
        }

    }
}

using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.Requests;

namespace FT.Travelako.Services.UserAPI.Services
{
    public class CreateUserservice : BaseExecutionService<CreateUserRequest>
    {
        public CreateUserservice() { }

        public override async Task<GenericAPIResponse> ExecuteApi(CreateUserRequest model)
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

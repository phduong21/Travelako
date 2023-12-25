using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.TravelAPI.Models.DTOs;

namespace FT.Travelako.Services.TravelAPI.Services
{
    public class GetTravelService : BaseExecutionService<GetTravelRequestDTO>
    {
        public GetTravelService() { }

        public override async Task<GenericAPIResponse> ExecuteApi(GetTravelRequestDTO model)
        {
            //logic here here
            //call to repo here
            return  new GenericAPIResponse
            {
                IsSuccess = true,
                Message = "123456789a-travel",
            };
        }

    }
}

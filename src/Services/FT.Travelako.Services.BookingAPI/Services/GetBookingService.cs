using FT.Travelako.Common.BaseImplementation;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.BookingAPI.Models.DTOs;

namespace FT.Travelako.Services.BookingAPI.Services
{
    public class GetBookingService : BaseExecutionService<GetBookingRequestDTO>
    {
        public GetBookingService() { }

        public override async Task<GenericAPIResponse> ExecuteApi(GetBookingRequestDTO model)
        {
            //logic here here
            //call to repo here
            return  new GenericAPIResponse
            {
                IsSuccess = true,
                Message = "123456789a-booking",
            };
        }

    }
}

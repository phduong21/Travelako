using FT.Travelako.Base.BaseImplementation;
using FT.Travelako.Base.BaseModels;
using FT.Travelako.Services.CouponAPI.Models.DTOs;

namespace FT.Travelako.Services.CouponAPI.Services
{
    public class GetCouponService : BaseExecutionService<GetCouponRequestDTO>
    {
        public GetCouponService() { }

        public override async Task<GenericAPIResponse> ExecuteApi(GetCouponRequestDTO model)
        {
            //logic here here
            //call to repo here
            return  new GenericAPIResponse
            {
                IsSuccess = true,
                Message = "123456789a",
            };
        }

    }
}

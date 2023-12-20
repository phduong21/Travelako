using FT.Travelako.Base.BaseModels;
using FT.Travelako.WebAPI.Services.IServices;
using static FT.Travelako.Base.BaseUtility.StaticData;
using static FT.Travelako.WebAPI.Constants.ApiDefinition;

namespace FT.Travelako.WebAPI.Services
{
    public class CouponService : ICouponService
    {
        private readonly IGatewayService _gatewayService;
        public CouponService(IGatewayService gatewayService) 
        {
            _gatewayService = gatewayService;
        }

        public async Task<GenericAPIResponse> GetCoupon(string code)
        {
            return await _gatewayService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = BaseCouponAPI + CouponApi.GetCoupon + code
            });
        }
    }
}

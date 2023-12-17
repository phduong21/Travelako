using FT.Travelako.WebAPI.Models.GenericAPI;
using FT.Travelako.WebAPI.Services.IServices;
using static FT.Travelako.WebAPI.Utility.ApiDefinition;
using static FT.Travelako.WebAPI.Utility.StaticData;

namespace FT.Travelako.WebAPI.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<GenericAPIResponse> GetCoupon(string code)
        {
            return await _baseService.ExecuteAsync(new GenericAPIRequest
            {
                ApiType = ApiType.GET,
                Url = BaseCouponAPI + CouponApi.GetCoupon + code
            });
        }
    }
}

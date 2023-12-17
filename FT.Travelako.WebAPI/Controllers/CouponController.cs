using FT.Travelako.WebAPI.Models.GenericAPI;
using FT.Travelako.WebAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.WebAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<GenericAPIResponse> GetCoupon(string code)
        {
            return await _couponService.GetCoupon(code);
        }
    }
}

using FT.Travelako.WebAPI.Base.Models;
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

        [HttpGet("{Code}")]
        public async Task<GenericAPIResponse> GetCoupon([FromRoute] string Code)
        {
            return await _couponService.GetCoupon(Code);
        }
    }
}

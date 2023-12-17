using FT.Travelako.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        [HttpGet]
        public async Task<GenericAPIResponse> GetCoupon(string code)
        {
            return new GenericAPIResponse()
            {
                IsSuccess = true,
                Message = "test",
                Result = new
                {
                    a = 1,
                    b = 2,
                    c = 3
                }
            };
        }
    }
}

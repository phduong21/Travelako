using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCoupon(string code)
        {
            var a = 1;
            return Ok();
        }
    }
}

using FT.Travelako.Services.CouponAPI.Base.Controller;
using FT.Travelako.Services.CouponAPI.Base.Models;
using FT.Travelako.Services.CouponAPI.Models.DTOs;
using FT.Travelako.Services.CouponAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : AppBaseController
    {
        public CouponController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        [HttpGet("{Code}")]
        public async Task<GenericAPIResponse> GetCoupon([FromRoute] GetCouponRequestDTO model)
        {
            return await ExecutionService<GetCouponRequestDTO, GetCouponService>(model);
        }
    }
}

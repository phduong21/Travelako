using FT.Travelako.Base.BaseModels;
using FT.Travelako.Base.Controller;
using FT.Travelako.Services.CouponAPI.Models.DTOs;
using FT.Travelako.Services.CouponAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("~/coupon-api/coupon")]
    [ApiController]
    public class CouponController : ApiBaseController
    {
        public CouponController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        [HttpGet]
        public async Task<GenericAPIResponse> GetCoupon([FromRoute] GetCouponRequestDTO? model)
        {
            return await ExecutionService<GetCouponRequestDTO, GetCouponService>(model);
        }
    }
}

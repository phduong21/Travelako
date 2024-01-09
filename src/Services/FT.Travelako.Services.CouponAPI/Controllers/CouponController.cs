using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.CouponAPI.Filter;
using FT.Travelako.Services.CouponAPI.Models.DTOs;
using FT.Travelako.Services.CouponAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ApiBaseController
    {
        private IDistributedCache _cache;
        public CouponController(IServiceProvider serviceProvider, IDistributedCache cache) : base(serviceProvider)
        {
            _cache = cache;
        }

        [HttpGet("GetCoupon")]
        [AuthorizeCouponFilter]
        [Authorize(Roles = "administrator")]
        public async Task<GenericAPIResponse> GetCoupon([FromRoute] GetCouponRequestDTO? model)
        {
            //return await ExecutionService<GetCouponRequestDTO, GetCouponService>(model);
            await Task.Delay(500);
            return new GenericAPIResponse();
        }


        [HttpGet("GetCouponAll")]
        [Authorize(Roles = "administrator")]
        public async Task<GenericAPIResponse> GetCouponAll([FromRoute] GetCouponRequestDTO? model)
        {
            return await ExecutionService<GetCouponRequestDTO, GetCouponService>(model);
        }
    }
}

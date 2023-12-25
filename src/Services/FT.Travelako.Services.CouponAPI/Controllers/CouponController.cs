using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.CouponAPI.Models.DTOs;
using FT.Travelako.Services.CouponAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
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


        [HttpGet("GetCouponAll")]
        [Authorize(Roles ="Admin")]
        public async Task<GenericAPIResponse> GetCouponAll([FromRoute] GetCouponRequestDTO? model)
        {
            return await ExecutionService<GetCouponRequestDTO, GetCouponService>(model);
        }
    }
}

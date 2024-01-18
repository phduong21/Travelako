using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Application.Features.Coupon.Commands.DeleteCoupon;
using Coupon.Application.Features.Coupon.Commands.UpdateCoupon;
using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using FT.Travelako.Common.BaseModels;
using FT.Travelako.Common.Controller;
using FT.Travelako.Services.CouponAPI.Filter;
using FT.Travelako.Services.CouponAPI.Models.DTOs;
using FT.Travelako.Services.CouponAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ApiBaseController
    {
        private IDistributedCache _cache;
        private readonly IMediator _mediator;
        public CouponController(IServiceProvider serviceProvider, IDistributedCache cache, IMediator mediator) : base(serviceProvider)
        {
            _cache = cache;
            _mediator = mediator;
        }



        [HttpGet("GetCouponsByUserId")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType(typeof(IEnumerable<CouponViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CouponViewModel>>> GetCouponsByUserId(string userId)
        {
            var query = new GetCouponsListQuery(userId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost("CreateCoupon")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCoupon([FromBody] CreateCouponCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateCoupon")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCoupon([FromBody] UpdateCouponCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("DeleteCoupon")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCoupon(string id)
        {
            var command = new DeleteCouponCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}

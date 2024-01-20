using FT.Travelako.Common.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using FT.Travelako.Services.CouponAPI.Services;
using MediatR;
using FT.Travelako.Services.CouponAPI.Filter;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId;
using Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon;
using Coupon.Application.Features.CouponsUser.Commands.UpdateUserCoupon;
using Coupon.Application.Features.CouponsUser.Commands.DeleteUserCoupon;

namespace FT.Travelako.Services.CouponAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserCouponController : ApiBaseController
    {
        private IDistributedCache _cache;
        private readonly IMediator _mediator;
        public UserCouponController(IServiceProvider serviceProvider, IDistributedCache cache, IMediator mediator) : base(serviceProvider)
        {
            _cache = cache;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }



        [HttpGet("GetUsersCouponsByUserId")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "user,business,administrator")]
        [ProducesResponseType(typeof(IEnumerable<CouponUserModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CouponUserModel>>> GetUsersCouponsByUserId(string userId, string businessUserId)
        {
            var query = new GetUserCouponsListQuery(userId, businessUserId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost("CreateUserCoupon")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateUserCoupon([FromBody] CreateUserCouponCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateUserCoupon")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUserCoupon([FromBody] UpdateUserCouponCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("DeleteUserCoupon")]
        [AuthorizeFTFilter]
        [Authorize(Roles = "business,administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUserCoupon(string id)
        {
            var command = new DeleteUserCouponCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}

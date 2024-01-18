using Booking.Application.Models;
using MediatR;

namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon
{
    public class CreateUserCouponCommand : IRequest<ApiResult<string>>
    {
        public string BusinessId { get; set; }

        public string UserId { get; set; }

        public bool? IsUsed { get; set; }
    }
}

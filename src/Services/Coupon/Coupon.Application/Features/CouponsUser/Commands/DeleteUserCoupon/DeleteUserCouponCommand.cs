using MediatR;

namespace Coupon.Application.Features.CouponsUser.Commands.DeleteUserCoupon
{
    public class DeleteUserCouponCommand : IRequest
    {
        public string Id { get; set; }
    }
}

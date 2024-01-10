using Booking.Application.Models;
using MediatR;

namespace Coupon.Application.Features.Coupon.Commands.CreateCoupon
{
    public class CreateCouponCommand : IRequest<ApiResult<string>>
    {
        public string Title { get; set; }

        public string Code { get; set; }

        public int Discount { get; set; }

        public int Condition { get; set; }

        public string? CreatedBy { get; set; }
    }
}

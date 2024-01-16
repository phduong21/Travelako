using Booking.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon
{
    public class CreateUserCouponCommand : IRequest<ApiResult<string>>
    {
        public string CouponId { get; set; }

        public string UserId { get; set; }

        public bool? IsUsed { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.CouponsUser.Commands.UpdateUserCoupon
{
    public class UpdateUserCouponCommand : IRequest
    {
        public string Id { get; set; }

        public string CouponId { get; set; }

        public string UserId { get; set; }

        public bool? IsUsed { get; set; }
    }
}

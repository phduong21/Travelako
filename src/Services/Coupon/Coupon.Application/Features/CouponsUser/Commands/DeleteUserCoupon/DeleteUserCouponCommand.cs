using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.CouponsUser.Commands.DeleteUserCoupon
{
    public class DeleteUserCouponCommand : IRequest
    {
        public string Id { get; set; }
    }
}

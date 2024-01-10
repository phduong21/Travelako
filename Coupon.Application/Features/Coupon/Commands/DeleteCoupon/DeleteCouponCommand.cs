using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Commands.DeleteCoupon
{
    public class DeleteCouponCommand : IRequest
    {
        public string Id { get; set; }
    }
}
